using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp
{
    public partial class Form1 : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Form1));
        public Form1()
        {
            Log.Info("Starting Form1");
            InitializeComponent();
            Log.Info("Finished Form1");
        }
    }
}