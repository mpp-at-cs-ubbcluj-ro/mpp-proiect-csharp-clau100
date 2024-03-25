using System;
using System.Collections.Generic;
using System.Windows.Forms;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Service;
using Spring.Context.Support;

namespace MPP_CSharp
{
    public partial class UserView : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserView));
        private readonly ConcursService _concursService;
        private readonly ParticipantService _participantService;
        public UserView()
        {
            Log.Info("Starting UserView...");
            var ctx = ContextRegistry.GetContext();
            _concursService =(ConcursService) ctx.GetObject("concursSrv");
            _participantService = (ParticipantService)ctx.GetObject("participantSrv");
            InitializeComponent();
            ReloadGridView();
            Log.Info("Closing UserView...");
        }

        private void ReloadGridView()
        {
            concursuriGrid.DataSource = _concursService.GetAll();
        }

        private void concursuriGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (concursuriGrid.SelectedRows.Count <= 0) return;
            var id =(long) concursuriGrid.SelectedRows[0].Cells[3].Value;
            var c = _concursService.Find(id);
            if (c is null) return;
            var lst = new List<Participant>();
            foreach (var participantId in c.Participanti)
            {
                var p = _participantService.Find(participantId);
                if (p is null) continue;
                lst.Add(p);
            }

            participantGrid.DataSource = lst;
        }
    }
}