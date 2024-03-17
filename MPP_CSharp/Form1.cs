using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Repository;

namespace MPP_CSharp
{
    public partial class Form1 : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Form1));
        private readonly UserRepo Users = new UserRepo();
        public Form1()
        {
            Log.Info("Starting Form1");
            try
            {
                Users.GetAll();
            }
            catch (SQLiteException e)
            {
                Log.Error(e.Message);
            }

            try
            {
                User u = Users.Find(100);
                if (u is null)
                {
                    Log.Info("Find works!");
                }
                else
                {
                    throw new InvalidOperationException("Find does not work!");
                }
            }
            catch (InvalidOperationException e)
            {
                Log.Error(e.Message);
            }
            InitializeComponent();
            Log.Info("Finished Form1");
        }
    }
}