using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using MPP_CSharp.Domain;
using MPP_CSharp.Tests;
using Spring.Context.Support;
using MPP_CSharp.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MPP_CSharp
{
    internal static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        private static UserService _userService;
        private static ConcursService _concursService;
        private static ParticipantService _participantService;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("../../LoggerConfig.xml"));
            var ctx = ContextRegistry.GetContext();
            
            RunTests();

            Log.Info("Application started");
            _userService = (UserService)ctx.GetObject("userSrv");
            _participantService = (ParticipantService)ctx.GetObject("participantSrv");
            _concursService = (ConcursService)ctx.GetObject("concursSrv");
            
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Log.Info("Application closed");
            */

            var loginListener = new Thread(() => StartListener(Ports.Login, HandleLogin));
            loginListener.Start();
            var concursListener = new Thread(() => StartListener(Ports.Concurs, HandleConcurs));
            concursListener.Start();
            var participantListener = new Thread(() => StartListener(Ports.Participant, HandleParticipant));
            participantListener.Start();
        }

        private static void StartListener(Ports port, Action<object> handler)
        {
            var listener = new TcpListener(IPAddress.Any, (int)port);
            listener.Start();
            Log.Info($"Listening for {port.ToString()}...");

            try
            {
                while (true)
                {
                    var client = listener.AcceptTcpClient();
                    Log.Info($"Client connected to port {port} from {client.Client.RemoteEndPoint}");

                    var clientThread = new Thread(new ParameterizedThreadStart(handler));
                    clientThread.Start(client);
                }
            }
            catch (ThreadAbortException)
            {
                Log.Error($"Listener on port {Ports.Login} stopped.");
            }
            listener.Stop();
        }

        private static void HandleLogin(object obj)
        {
            var client = (TcpClient)obj;
            var stream = client.GetStream();

            try
            {
                var buffer = new byte[4096];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                var jsonData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                var receivedUser = JsonConvert.DeserializeObject<User>(jsonData);

                Console.WriteLine($@"Reveived User from client: {receivedUser.Username}|{receivedUser.Password}");

                var isGood = _userService.CheckUser(receivedUser);
                var json = JsonConvert.SerializeObject(isGood);
                var responseData = Encoding.UTF8.GetBytes(json);
                stream.Write(responseData, 0, responseData.Length);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            stream.Close();
            client.Close();
        }

        private static void HandleConcurs(object obj)
        {
            var client = (TcpClient)obj;
            var stream = client.GetStream();

            try
            {
                var concursuri = _concursService.GetAll();
                var jsonData = JsonConvert.SerializeObject(concursuri);

                var data = Encoding.UTF8.GetBytes(jsonData);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            stream.Close();
            client.Close();
        }

        private static void HandleParticipant(object obj)
        {
            var client = (TcpClient)obj;
            var stream = client.GetStream();

            try
            {
                var buffer = new byte[4096];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                var jsonData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                var receivedIds = JsonConvert.DeserializeObject<List<long>>(jsonData);

                var found = receivedIds.Select(receivedId => _participantService.Find(receivedId)).ToList();

                jsonData = JsonConvert.SerializeObject(found);

                var data = Encoding.UTF8.GetBytes(jsonData);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            stream.Close();
            client.Close();
        }
        
        private static void RunTests()
        {
            Log.Info("Testing...");
            TestUserRepo.TestAll();
            TestParticipantRepo.TestAll();
            TestConcursRepo.TestAll();
        }
    }
}