using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nikolay_tashev_employess.Base.LogSystem;

namespace nikolay_tashev_employess.Base.Common.Exceptions
{
    public class BaseSystemException : Exception
    {
        public BaseSystemException(string message)
            : this(message, null)
        {
        }

        public BaseSystemException(string message, Exception innerException)
            : base(message, innerException)
        {
            FileLogger.Instance.LogMessage(message, String.Empty);

            if (innerException != null)
                FileLogger.Instance.LogException(innerException);
        }
    }
}
