using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nikolay_tashev_employess.Base.LogSystem.Interfaces
{
    public interface ILogger
    {
        void LogException(Exception exception);
        void LogMessage(string message, string additionalInfo);
    }
}
