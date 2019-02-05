using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using nikolay_tashev_employess.Models;
using nikolay_tashev_employess.Base.FileOperations;
using nikolay_tashev_employess.Base.Common.Interfaces;
using nikolay_tashev_employess.Base.FileOperations.Interfaces;
using nikolay_tashev_employess.BussinessLogic;

namespace nikolay_tashev_employess.BussinessLogic
{
    public static class EmployeeHelper
    {
        /// <summary> Asynchronously loads a list of employees from file </summary>
        public static async Task<List<Employee>> LoadEmployeesFromFileAsync(string filePath)
        {
            return await Task<List<Employee>>.Run<List<Employee>>(() => { return LoadEmployeesFromFile(filePath); });
        }

        /// <summary> Loads a list of employees from file </summary>
        public static List<Employee> LoadEmployeesFromFile(string filePath)
        {
            IFileParser<Employee> employeeFileParser = new EmployeeFileParser();
            IDataLoader<Employee> employeeFileLoader = new FileDataLoader<Employee>(filePath, employeeFileParser);
            return employeeFileLoader.LoadData();
        }

        /// <summary> Asynchronously loads a list of employees pair working on same project </summary>
        public static async Task<List<EmployeesWorkingPair>> LoadEmployeesWorkingPairAsync(List<Employee> employees)
        {
            return await Task.Run< List < EmployeesWorkingPair >>(() => { return LoadEmployeesWorkingPair(employees); });
        }

        /// <summary> Loads a list of employees pair working on same project </summary>
        public static List<EmployeesWorkingPair> LoadEmployeesWorkingPair(List<Employee> employees)
        {
            EmployeesWorkingPairsParser parser = new EmployeesWorkingPairsParser(employees);
            return parser.LoadEmployeesWorkingPairV2();
        }
    }
}
