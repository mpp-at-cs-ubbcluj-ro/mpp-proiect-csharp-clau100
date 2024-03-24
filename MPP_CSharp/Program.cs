using System;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using MPP_CSharp.Tests;

namespace MPP_CSharp
{
    internal static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("../../LoggerConfig.xml"));
            Log.Info("Testing...");
            var ok =TestUserRepo.TestAll();
            ok &= TestParticipantRepo.TestAll();
            ok &= TestConcursRepo.TestAll();
            if (!ok)
            {
                throw new TestingException("Tests failed!");
            }

            Log.Info("Application started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Log.Info("Application closed");
        }
    }
}