using System;
using System.IO;
using System.Globalization;
using nikolay_tashev_employess.Base.LogSystem.Interfaces;

namespace nikolay_tashev_employess.Base.LogSystem
{
    public class FileLogger : ILogger
    {
        private static readonly string applicationName = AppDomain.CurrentDomain.FriendlyName;
        private static readonly string workingDirectory = System.Environment.CurrentDirectory;
        private static readonly object lockingObject = new object();
        private static ILogger instance = null;

        private FileLogger() { }

        public static ILogger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockingObject)
                    {
                        instance = new FileLogger();
                    }
                }

                return instance;
            }
        }

        /// <summary> Saves information about message and stack trace of an exception into the log file </summary>
        public void LogException(Exception exception)
        {
            try
            {
                lock (lockingObject)
                {
                    LogMessage(exception.Message, exception.StackTrace);
                }
            }
            catch { }
        }

        /// <summary> Saves information about message and additional message info into the log file </summary>
        public void LogMessage(string message, string additionalInfo)
        {
            try
            {
                lock (lockingObject)
                {
                    using (StreamWriter streamWriter = File.AppendText(GetFullFilePath()))
                    {
                        streamWriter.WriteLine("{0}\t{1}\t{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), message, additionalInfo);
                        streamWriter.Close();
                    }
                }
            }
            catch { }
        }

        /// <summary> Retrieves the path of the log file </summary>
        private string GetFullFilePath()
        {
            string dateNow = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            string fileName = dateNow + "_" + applicationName + ".log";
            return Path.Combine(workingDirectory, fileName);
        }
    }
}
