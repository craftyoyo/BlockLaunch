using System;
using System.Windows.Forms;
using BlockLaunch.Classes;
using BlockLaunch.UI.Forms;

namespace BlockLaunch
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.Run(new FrmMain());
        }

        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
             UnhandledExceptionManager.Tracker.Track((Exception) e.ExceptionObject);
        }
    }
}
