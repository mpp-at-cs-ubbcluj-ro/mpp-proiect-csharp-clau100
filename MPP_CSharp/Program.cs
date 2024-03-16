using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace MPP_CSharp
{
    static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("../../LoggerConfig.xml"));
            Log.Info("Application started");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Log.Info("Application closed");
        }
    }
}