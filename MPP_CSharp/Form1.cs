using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Repository;

namespace MPP_CSharp
{
    public partial class Form1 : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Form1));
        private readonly UserRepo users = new UserRepo(testing: false);
        private readonly ConcursRepo concursuri = new ConcursRepo(testing: false);
        public Form1()
        {
            Log.Info("Starting Form1");
            var all_concurs = concursuri.GetAll();
            foreach (var c in all_concurs)
            {
                Log.Info("Concurs cu id="+c.Id+" cu participanti:");
                foreach (var p in c.Participanti)
                {
                    Log.Info("Participant cu id="+p);
                }
            }
            InitializeComponent();
            Log.Info("Finished Form1");
        }
    }
}