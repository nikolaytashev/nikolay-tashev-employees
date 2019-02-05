using nikolay_tashev_employess.Base.Common;
using nikolay_tashev_employess.Base.Common.Exceptions;
using nikolay_tashev_employess.Base.FileOperations.Interfaces;
using nikolay_tashev_employess.Models;
using System;

namespace nikolay_tashev_employess.BussinessLogic
{
    /// <summary> Class that parses file line to object of type Employee </summary>
    class EmployeeFileParser : IFileParser<Employee>
    {
        public Employee ParseData(string data, int currentRow)
        {
            var columns = data.Split(',');
            if (columns.Length != 4)
                throw new BaseSystemException("Invalid columns for row " + currentRow);

            int employeeID, projectID;
            DateTime dateFrom, dateTo;

            if (!int.TryParse(columns[0].Trim(), out employeeID))
                throw new BaseSystemException("Invalid Employee ID for row " + currentRow);

            if (!int.TryParse(columns[1].Trim(), out projectID))
                throw new BaseSystemException("Invalid ProjectID ID for row " + currentRow);

            if (!Utilities.ParseDate(columns[2].Trim(), out dateFrom))
                throw new BaseSystemException("Invalid Date From for row " + currentRow);

            if (!Utilities.ParseDate(columns[3].Trim(), out dateTo))
                throw new BaseSystemException("Invalid Date To for row " + currentRow);

            return new Employee()
            {
                EmployeeID = employeeID,
                ProjectID = projectID,
                DateFrom = dateFrom,
                DateTo = dateTo
            };
        }
    }
}
