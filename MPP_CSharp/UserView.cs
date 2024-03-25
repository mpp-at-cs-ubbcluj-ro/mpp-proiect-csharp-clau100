using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            ReloadGridViews();
            Log.Info("Closing UserView...");
        }

        private void ReloadGridViews()
        {
            concursuriGrid.DataSource = _concursService.GetAll();
            totiParticipanti.DataSource = _participantService.GetAll();
        }

        private void concursuriGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (concursuriGrid.SelectedRows.Count <= 0) return;
            var id =(long) concursuriGrid.SelectedRows[0].Cells["id"].Value;
            var c = _concursService.Find(id);
            if (c is null) return;
            var lst = new List<Participant>();
            foreach (var pId in c.Participanti)
            {
                var p = _participantService.Find(pId);
                if (p is null) continue;
                lst.Add(p);
            }
            participantGrid.DataSource = lst;
        }

        private void register_Click(object sender, EventArgs e)
        {
            string nume;
            int varsta;
            try
            {
                nume = textNume.Text;
                varsta = Convert.ToInt32(textboxVarsta.Text);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return;
            }

            var participant = new Participant(1, varsta, nume, new List<long>());
            _participantService.Add(participant);
            ReloadGridViews();
        }

        private void enroll_Click(object sender, EventArgs e)
        {
            if (concursuriGrid.SelectedRows.Count <= 0) return;
            if (totiParticipanti.SelectedRows.Count <= 0) return;

            var cId = (long)concursuriGrid.SelectedRows[0].Cells["id"].Value;
            var pId = (long)totiParticipanti.SelectedRows[0].Cells["id"].Value;
            
            _concursService.Inregistreaza(cId, pId);
            ReloadGridViews();
        }

        private void participantGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat() 
            { 
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center, 
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}