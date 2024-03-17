using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class ParticipantRepo : IRepo<Participant, long>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepo));

        private static readonly string ConnectionString =
            @"Data Source=C:\Users\user\RiderProjects\mpp-proiect-csharp-clau100\MPP_CSharp\DB.sqlite;";
        public List<Participant> GetAll()
        {
            List<Participant> arr = new List<Participant>();
            Log.Info("Fetching all Participanti from DB");
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Participant", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long id = reader.GetInt64(reader.GetOrdinal("id"));
                            int varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                            Participant p = new Participant(id, varsta, new long[] { });
                            arr.Add(p);
                            Log.Info("Found participant with id="+id);
                        }
                    }
                }
            }
            return arr;
        }

        public Participant Find(long id)
        {
            Log.Info("Trying to find Participant with id="+id);
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(@"SELECT * FROM Participant where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                            Participant p = new Participant(id, varsta, new long[] { });
                            Log.Info("Found participant with id="+id);
                            return p;
                        }
                    }
                }
            }
            Log.Warn("Found no participant with id="+id);
            return null;
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Participant toAdd)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Participant toUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}