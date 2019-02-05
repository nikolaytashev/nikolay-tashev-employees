using nikolay_tashev_employess.Base.Common;
using nikolay_tashev_employess.Models;
using System;
using System.Collections.Generic;

namespace nikolay_tashev_employess.BussinessLogic
{
    public class EmployeesWorkingPairsParser
    {
        public class EmployeeProjectWorkingDaysKey
        {
            public int ProjectID { get; set; }
            public int EmployeeID1 { get; set; }
            public int EmployeeID2 { get; set; }

            public class EqualityComparer : IEqualityComparer<EmployeeProjectWorkingDaysKey>
            {
                public bool Equals(EmployeeProjectWorkingDaysKey item1, EmployeeProjectWorkingDaysKey item2)
                {
                    return item1.ProjectID == item2.ProjectID && item1.EmployeeID1 == item2.EmployeeID1 && item1.EmployeeID2 == item2.EmployeeID2;
                }

                public int GetHashCode(EmployeeProjectWorkingDaysKey obj)
                {
                    return obj.ProjectID ^ obj.EmployeeID1 ^ obj.EmployeeID2;
                }
            }
        }

        private List<Employee> employees;
        public EmployeesWorkingPairsParser(List<Employee> employees)
        {
            this.employees = employees;
        }

        /// <summary> Loads a list of employees pair working on same project </summary>
        public List<EmployeesWorkingPair> LoadEmployeesWorkingPairV1()
        {
            Dictionary<int, List<Employee>> projectToEmployeesDictionary = new Dictionary<int, List<Employee>>();
            employees.ForEach((employee) =>
            {
                if (projectToEmployeesDictionary.ContainsKey(employee.ProjectID))
                {
                    var value = projectToEmployeesDictionary[employee.ProjectID];
                    value.Add(employee);
                }
                else
                {
                    List<Employee> workingDaysList = new List<Employee>() { employee };
                    projectToEmployeesDictionary.Add(employee.ProjectID, workingDaysList);
                }
            });

            Dictionary<EmployeeProjectWorkingDaysKey, int> projectToEmployeesWorkingPairs = new Dictionary<EmployeeProjectWorkingDaysKey, int>(new EmployeeProjectWorkingDaysKey.EqualityComparer());

            foreach (var item in projectToEmployeesDictionary)
            {
                var employeesValue = item.Value;

                // We need at least 2 employees working on one project
                if (employeesValue.Count <= 0)
                    continue;

                for (int index = 0; index < employeesValue.Count; index++)
                {
                    var foundItems = employeesValue.FindAll((value) => { return employeesValue[index].EmployeeID != value.EmployeeID; });
                    foreach (var foundItem in foundItems)
                    {
                        DateTime beginDate = Utilities.Max(employeesValue[index].DateFrom, foundItem.DateFrom),
                                 endDate = Utilities.Min(employeesValue[index].DateTo, foundItem.DateTo);

                        // Check if we have matching periods
                        if (beginDate > endDate)
                            continue;

                        EmployeeProjectWorkingDaysKey key = new EmployeeProjectWorkingDaysKey()
                        {
                            ProjectID = employeesValue[index].ProjectID,
                            EmployeeID1 = Utilities.Min(employeesValue[index].EmployeeID, foundItem.EmployeeID),
                            EmployeeID2 = Utilities.Max(employeesValue[index].EmployeeID, foundItem.EmployeeID)
                        };

                        if (projectToEmployeesWorkingPairs.ContainsKey(key))
                        {
                            var DaysWorked = projectToEmployeesWorkingPairs[key];
                            projectToEmployeesWorkingPairs[key] += (int)Utilities.CountDaysBetweenDates(beginDate, endDate);
                        }
                        else
                        {
                            projectToEmployeesWorkingPairs.Add(key, (int)Utilities.CountDaysBetweenDates(beginDate, endDate));
                        }
                    }
                }
            }

            List<EmployeesWorkingPair> employeesWorkingPairs = new List<EmployeesWorkingPair>(projectToEmployeesWorkingPairs.Count);
            foreach (var item in projectToEmployeesWorkingPairs)
            {
                employeesWorkingPairs.Add(new EmployeesWorkingPair()
                {
                    ProjectID = item.Key.ProjectID,
                    FirstEmployeeID = item.Key.EmployeeID1,
                    SecondEmployeeID = item.Key.EmployeeID2,
                    DaysWorked = item.Value
                });
            }

            return employeesWorkingPairs;
        }

        /// <summary> Loads a list of employees pair working on same project </summary>
        public List<EmployeesWorkingPair> LoadEmployeesWorkingPairV2()
        {
            Dictionary<int, List<Employee>> projectToEmployeesDictionary = new Dictionary<int, List<Employee>>();
            employees.ForEach((employee) =>
            {
                if (projectToEmployeesDictionary.ContainsKey(employee.ProjectID))
                {
                    var value = projectToEmployeesDictionary[employee.ProjectID];
                    value.Add(employee);
                }
                else
                {
                    List<Employee> workingDaysList = new List<Employee>() { employee };
                    projectToEmployeesDictionary.Add(employee.ProjectID, workingDaysList);
                }
            });

            Dictionary<int, Dictionary<int, Dictionary<int, int>>> projectToEmployeePairToWorkDays = new Dictionary<int, Dictionary<int, Dictionary<int, int>>>();
            foreach (var projectsItem in projectToEmployeesDictionary)
            {
                var employeesValue = projectsItem.Value;

                // We need at least 2 employees working on one project
                if (employeesValue.Count < 2)
                    continue;

                for (int index = 0; index < employeesValue.Count - 1; index++)
                {
                    var employee = employeesValue[index];

                    for (int searchIndex = index + 1; searchIndex < employeesValue.Count; searchIndex++)
                    {
                        var foundEmployee = employeesValue[searchIndex];

                        if (foundEmployee.EmployeeID == employee.EmployeeID)
                            continue;

                        DateTime beginDate = Utilities.Max(employee.DateFrom, foundEmployee.DateFrom),
                                 endDate = Utilities.Min(employee.DateTo, foundEmployee.DateTo);

                        // Check if we have matching periods
                        if (beginDate > endDate)
                            continue;

                        int workDays = (int)Utilities.CountDaysBetweenDates(beginDate, endDate);

                        AddProjectToEmployeePairDictionary(employee.ProjectID, employee.EmployeeID, foundEmployee.EmployeeID, workDays, ref projectToEmployeePairToWorkDays);
                    }
                }
            }

            Dictionary<EmployeeProjectWorkingDaysKey, int> projectToEmployeesWorkingPairs = new Dictionary<EmployeeProjectWorkingDaysKey, int>(new EmployeeProjectWorkingDaysKey.EqualityComparer());
            foreach (var project in projectToEmployeePairToWorkDays)
            {
                foreach (var firstEmployee in project.Value)
                {
                    foreach (var secondEmployee in firstEmployee.Value)
                    {
                        EmployeeProjectWorkingDaysKey key = new EmployeeProjectWorkingDaysKey()
                        {
                            ProjectID = project.Key,
                            EmployeeID1 = Utilities.Min(firstEmployee.Key, secondEmployee.Key),
                            EmployeeID2 = Utilities.Max(firstEmployee.Key, secondEmployee.Key)
                        };

                        // Lets create the unique pairs
                        if (!projectToEmployeesWorkingPairs.ContainsKey(key))
                        {
                            projectToEmployeesWorkingPairs.Add(key, secondEmployee.Value);
                        }
                    }
                }
            }

            List<EmployeesWorkingPair> employeesWorkingPairs = new List<EmployeesWorkingPair>(projectToEmployeesWorkingPairs.Count);
            foreach (var item in projectToEmployeesWorkingPairs)
            {
                employeesWorkingPairs.Add(new EmployeesWorkingPair()
                {
                    ProjectID = item.Key.ProjectID,
                    FirstEmployeeID = item.Key.EmployeeID1,
                    SecondEmployeeID = item.Key.EmployeeID2,
                    DaysWorked = item.Value
                });
            }

            return employeesWorkingPairs;
        }

        /// <summary> Adds project with employees working together to a map </summary>
        private void AddProjectToEmployeePairDictionary(int projectID, int employeeID1, int employeeID2, int workDays, ref Dictionary<int, Dictionary<int, Dictionary<int, int>>> dictionary)
        {
            if (dictionary.ContainsKey(projectID))
            {
                var value = dictionary[projectID];
                AddEmployeePairToProject(employeeID1, employeeID2, workDays, ref value);
            }
            else
            {
                var value = new Dictionary<int, Dictionary<int, int>>();
                dictionary.Add(projectID, value);
                AddEmployeePairToProject(employeeID1, employeeID2, workDays, ref value);
            }
        }

        /// <summary> Adds employees working together to a map </summary>
        private void AddEmployeePairToProject(int employeeID1, int employeeID2, int workDays, ref Dictionary<int, Dictionary<int, int>> dictionary)
        {
            if (dictionary.ContainsKey(employeeID1))
            {
                var value = dictionary[employeeID1];
                AddWorkDaysToEmployee(employeeID2, workDays, ref value);
            }
            else
            {
                var value = new Dictionary<int, int>();
                dictionary.Add(employeeID1, value);
                AddWorkDaysToEmployee(employeeID2, workDays, ref value);
            }
        }

        /// <summary> Adds the count of working days between two employees </summary>
        private void AddWorkDaysToEmployee(int employeeID, int workDays, ref Dictionary<int, int> dictionary)
        {
            if (dictionary.ContainsKey(employeeID))
            {
                dictionary[employeeID] += workDays;
            }
            else
            {
                dictionary.Add(employeeID, workDays);
            }
        }
    }
}
