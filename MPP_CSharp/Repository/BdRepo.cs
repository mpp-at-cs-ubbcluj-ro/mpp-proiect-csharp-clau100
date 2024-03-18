using System.Configuration;
using System.Data;
using System.Data.SQLite;
using log4net;

namespace MPP_CSharp.Repository
{
    public abstract class BdRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(BdRepo));
        private readonly string connectionString;
        private static SQLiteConnection _connection;
        protected BdRepo(bool testing)
        {
            connectionString = testing ? ConfigurationManager.ConnectionStrings["TestString"].ConnectionString : ConfigurationManager.ConnectionStrings["DBString"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                Log.Error("Connection string is null or empty!");
            }
        }

        protected SQLiteConnection GetConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                return _connection;
            Log.Info("Trying to open Connection to server: "+connectionString);
            _connection = new SQLiteConnection(connectionString);
            _connection.Open();

            return _connection;
        }
    }
}