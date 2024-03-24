using System;
using System.Windows.Forms;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Service;
using Spring.Context.Support;
using Spring.Validation;

namespace MPP_CSharp
{
    public partial class Form1 : Form
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Form1));
        private readonly UserService _userService;
        public Form1()
        {
            Log.Info("Starting Login Form");
            var ctx = ContextRegistry.GetContext();
            _userService =(UserService) ctx.GetObject("userSrv");
            InitializeComponent();
            Log.Info("Finished Login Form");
        }

        private void login_Click(object sender, EventArgs e)
        {
            var u = new User(0, usernameInput.Text, passwordInput.Text);
            var errs = new ValidationErrors();
            _userService.Validator.Validate(u, errs);
            usernameError.Visible = errs.GetErrors("Username").Count > 0;

            passwordError.Visible = errs.GetErrors("Password").Count > 0;

            if (!errs.IsEmpty) return;

            loginError.Visible = _userService.CheckUser(u);

            if (loginError.Visible) return;
            
            // login the user
        }
    }
}