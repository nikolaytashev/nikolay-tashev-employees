using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace nikolay_tashev_employess
{
    static class Program
    {
        private static void SystemExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs exceptionArguments)
        {
            nikolay_tashev_employess.Base.LogSystem.FileLogger.Instance.LogException(exceptionArguments.Exception);
            MessageBox.Show("An error occurred. Please review log file");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(SystemExceptionHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
