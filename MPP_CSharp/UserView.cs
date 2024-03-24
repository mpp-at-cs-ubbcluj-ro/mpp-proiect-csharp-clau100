using System.Windows.Forms;
using log4net;
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
    }
}