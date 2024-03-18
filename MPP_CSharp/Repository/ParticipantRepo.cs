using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class ParticipantRepo : BdRepo, IParticipantRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepo));

        public ParticipantRepo(bool testing) : base(testing)
        {
            Log.Info("Inizializing new ParticipantRepo...");
        }
        
        public List<Participant> GetAll()
        {
            var arr = new List<Participant>();
            Log.Info("Fetching all Participanti from DB");
            var connection = GetConnection();
            using (var command = new SQLiteCommand("SELECT * FROM Participant", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(reader.GetOrdinal("id"));
                        var varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                        var p = new Participant(id, varsta, new long[] { });
                        arr.Add(p);
                        Log.Info("Found participant with id="+id);
                    }
                }
            }
            return arr;
        }

        public Participant Find(long id)
        {
            Log.Info("Trying to find Participant with id="+id);
            var connection = GetConnection();
            using (var command = new SQLiteCommand(@"SELECT * FROM Participant where id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                        var p = new Participant(id, varsta, new long[] { });
                        Log.Info("Found participant with id=" + id);
                        return p;
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

        public IEnumerable<Participant> FindAllFromList(IEnumerable<long> participantIDs)
        {
            var lst = new LinkedList<Participant>();
            return lst;
        }
    }
}