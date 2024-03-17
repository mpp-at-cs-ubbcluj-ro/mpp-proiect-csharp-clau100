using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.UI.WebControls;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class ConcursRepo : IRepo<Concurs, long>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepo));

        private static readonly string ConnectionString =
            @"Data Source=C:\Users\user\RiderProjects\mpp-proiect-csharp-clau100\MPP_CSharp\DB.sqlite;";
        public List<Concurs> GetAll()
        {
            List<Concurs> arr = new List<Concurs>();
            Log.Info("Fetching all Concurs from DB");
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Concurs", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(reader.GetOrdinal("id"));
                            string proba = reader.GetString(reader.GetOrdinal("Proba"));
                            int varstaMin = reader.GetInt32(reader.GetOrdinal("VarstaMin"));
                            int varstaMax = reader.GetInt32(reader.GetOrdinal("VarstaMax"));
                            Concurs c = new Concurs(id, proba, varstaMin, varstaMax, new long[] { });
                            arr.Add(c);
                            Log.Info("Found Concurs with id="+id);
                        }
                    }
                }
            }
            return arr;
        }

        public Concurs Find(long id)
        {
            Log.Info("Trying to find Concurs with id="+id);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(@"SELECT * FROM Concurs where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string proba = reader.GetString(reader.GetOrdinal("Proba"));
                            int varstaMin = reader.GetInt32(reader.GetOrdinal("VarstaMin"));
                            int varstaMax = reader.GetInt32(reader.GetOrdinal("VarstaMax"));
                            Concurs c = new Concurs(id, proba, varstaMin, varstaMax, new long[] { });
                            Log.Info("Found Concurs with id="+id);
                            return c;
                        }
                    }
                }
            }
            Log.Warn("Found no Concurs with id="+id);
            return null;
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Concurs toAdd)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Concurs toUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}