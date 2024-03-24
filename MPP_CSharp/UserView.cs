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
        public UserView()
        {
            InitializeComponent();
            var ctx = ContextRegistry.GetContext();
            _concursService =(ConcursService) ctx.GetObject("concursSrv");
        }
    }
}