using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nikolay_tashev_employess.Base.Common
{
    public static class Utilities
    {
        private static readonly string[] dateTimeFormates = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt", 
                                                            "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss", 
                                                            "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", 
                                                            "M/d/yyyy h:mm", "M/d/yyyy h:mm", 
                                                            "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm",
                                                            "yyyyMMdd"};

        public static bool ParseDate(string s, out DateTime date)
        {
            if (String.Compare(s, "NULL", true) == 0)
            {
                date = DateTime.Now;
                return true;
            }

            // Simple date format
            if (DateTime.TryParse(s, out date))
                return true;

            // Custom date format
            if (DateTime.TryParseExact(s, dateTimeFormates,System.Globalization.CultureInfo.InvariantCulture,
                                                System.Globalization.DateTimeStyles.AllowWhiteSpaces, out date))
                return true;

            return false;
        }

        public static double CountDaysBetweenDates(DateTime startingDate, DateTime endingDate)
        {
            if (startingDate > endingDate)
                throw new nikolay_tashev_employess.Base.Common.Exceptions.BaseSystemException("Starting date can not be grater than ending date");

            return (endingDate - startingDate).TotalDays;
        }

        public static Type Max<Type>(Type first, Type second)
        {
            if (Comparer<Type>.Default.Compare(first, second) > 0)
                return first;
            return second;
        }

        public static Type Min<Type>(Type first, Type second)
        {
            if (Comparer<Type>.Default.Compare(first, second) < 0)
                return first;
            return second;
        }
    }
}
