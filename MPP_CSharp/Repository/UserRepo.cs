using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class UserRepo : IRepo<User, long>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepo));

        private const string ConnectionString = @"Data Source=C:\Users\user\RiderProjects\mpp-proiect-csharp-clau100\MPP_CSharp\DB.sqlite;";

        public List<User> GetAll()
        {
            var arr = new List<User>();
            Log.Info("Fetching all Users from DB");
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM User", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt64(reader.GetOrdinal("id"));
                            var username = reader.GetString(reader.GetOrdinal("Username"));
                            var password = reader.GetString(reader.GetOrdinal("Password"));
                            var user = new User(id, username, password);
                            arr.Add(user);
                            Log.Info("Found user with id="+id);
                        }
                    }
                }
            }
            return arr;
        }

        public User Find(long id)
        {
            Log.Info("Trying to find User with id=" + id);
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(@"SELECT * FROM User where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Log.Info("Found user with id="+id);
                            var username = reader.GetString(reader.GetOrdinal("Username"));
                            var password = reader.GetString(reader.GetOrdinal("Password"));
                            var user = new User(id, username, password);
                            return user;
                        }
                    }
                }
            }
            Log.Warn("Found no user with id="+id);
            return null;
        }

        public void Delete(long id)
        {
            Log.Info("Trying to delete User with id=" + id);
            throw new System.NotImplementedException();
        }

        public void Add(User toAdd)
        {
            Log.Info("Trying to add a User");
            throw new System.NotImplementedException();
        }

        public void Update(User toUpdate)
        {
            Log.Info("Trying to update a User");
            throw new System.NotImplementedException();
        }
    }
}