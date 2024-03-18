using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class ConcursRepo : BdRepo, IConcursRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserRepo));

        public ConcursRepo(bool testing) : base(testing)
        {
            Log.Info("Initializing ConcursRepo...");
        }
        public List<Concurs> GetAll()
        {
            var arr = new List<Concurs>();
            Log.Info("Fetching all Concurs from DB");
            var connection = GetConnection();
            using (var command = new SQLiteCommand("SELECT * FROM Concurs", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(reader.GetOrdinal("id"));
                        var proba = reader.GetString(reader.GetOrdinal("Proba"));
                        var varstaMin = reader.GetInt32(reader.GetOrdinal("VarstaMin"));
                        var varstaMax = reader.GetInt32(reader.GetOrdinal("VarstaMax"));
                        var c = new Concurs(id, proba, varstaMin, varstaMax, new long[] { });
                        arr.Add(c);
                        Log.Info("Found Concurs with id="+id);
                    }
                }
            }
            return arr;
        }

        public Concurs Find(long id)
        {
            Log.Info("Trying to find Concurs with id="+id);
            var connection = GetConnection();
            using (var command = new SQLiteCommand(@"SELECT * FROM Concurs where id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var proba = reader.GetString(reader.GetOrdinal("Proba"));
                        var varstaMin = reader.GetInt32(reader.GetOrdinal("VarstaMin"));
                        var varstaMax = reader.GetInt32(reader.GetOrdinal("VarstaMax"));
                        var c = new Concurs(id, proba, varstaMin, varstaMax, new long[] { });
                        Log.Info("Found Concurs with id="+id);
                        return c;
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

        public IEnumerable<Concurs> FindAllFromAgeRange(int minAge, int maxAge)
        {
            var lst = new LinkedList<Concurs>();
            return lst;
        }
    }
}