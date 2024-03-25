using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class ConcursRepo : BdRepo, IConcursRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConcursRepo));

        public ConcursRepo(bool testing = false) : base(testing)
        {
            Log.Info("Initializing ConcursRepo...");
        }
        public List<Concurs> GetAll()
        {
            var arr = new List<Concurs>();
            Log.Info("Fetching all Concurs from DB");
            var connection = GetConnection();
            using (var command = new SQLiteCommand("SELECT * FROM Concurs c INNER JOIN Inscrieri i ON c.id = i.concurs", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(reader.GetOrdinal("id"));
                        var found = false;
                        foreach (var t in arr)
                        {
                            if (t.Id != id) continue;
                            var participantId = reader.GetInt64(reader.GetOrdinal("participant"));
                            Log.Info("Participant cu id="+participantId);
                            t.Participanti.Add(participantId);
                            found = true;
                        }

                        if (found)
                        {
                            continue;
                        }

                        var proba = reader.GetString(reader.GetOrdinal("Proba"));
                        var varstaMin = reader.GetInt32(reader.GetOrdinal("VarstaMin"));
                        var varstaMax = reader.GetInt32(reader.GetOrdinal("VarstaMax"));
                        var pId = reader.GetInt64(reader.GetOrdinal("participant"));
                        var lst = new List<long> { pId };
                        var c = new Concurs(id, proba, varstaMin, varstaMax, lst);
                        
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
            using (var command = new SQLiteCommand(@"SELECT * FROM Concurs c LEFT JOIN Inscrieri i on c.id = i.concurs where c.id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    Concurs concurs = null;
                    while (reader.Read())
                    {
                        if (concurs is null)
                        {
                            var proba = reader.GetString(reader.GetOrdinal("Proba"));
                            var varstaMin = reader.GetInt32(reader.GetOrdinal("VarstaMin"));
                            var varstaMax = reader.GetInt32(reader.GetOrdinal("VarstaMax"));
                            concurs = new Concurs(id, proba, varstaMin, varstaMax, new List<long>());
                        }

                        var participant = reader.GetInt64(reader.GetOrdinal("participant"));
                        concurs.Participanti.Add(participant);
                        Log.Info("Found Concurs with id="+id+" and with participant="+participant);
                    }

                    if (concurs is null)
                    {
                        Log.Error("Found no concurs with id="+id);
                    }
                    return concurs;
                }
            }
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

        public IEnumerable<Concurs> FindAllForAge(int age)
        {
            Log.Info("Trying to find all Concurs for age: "+age);
            var arr = new List<Concurs>();
            var connection = GetConnection();
            using (var command = new SQLiteCommand(@"SELECT * FROM Concurs c LEFT JOIN Inscrieri i on c.id = i.concurs WHERE @age >= VarstaMin and @age <= VarstaMax", connection))
            {
                command.Parameters.AddWithValue("@age", age);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(reader.GetOrdinal("id"));
                        var found = false;
                        foreach (var t in arr)
                        {
                            if (t.Id != id) continue;
                            var participantId = reader.GetInt64(reader.GetOrdinal("participant"));
                            t.Participanti.Add(participantId);
                            found = true;
                        }

                        if (found)
                        {
                            continue;
                        }

                        var proba = reader.GetString(reader.GetOrdinal("Proba"));
                        var varstaMin = reader.GetInt32(reader.GetOrdinal("VarstaMin"));
                        var varstaMax = reader.GetInt32(reader.GetOrdinal("VarstaMax"));
                        var pId = reader.GetInt64(reader.GetOrdinal("participant"));
                        var lst = new List<long> { pId };
                        var c = new Concurs(id, proba, varstaMin, varstaMax, lst);
                        
                        arr.Add(c);
                        Log.Info("Found Concurs with id="+id);
                    }
                }
            }
            return arr;
        }

        public void Inregistreaza(long cId, long pId)
        {
            Log.Info("Enrolling participant with id="+pId+" to concurs with id="+cId);
            var connection = GetConnection();
            using (var command = new SQLiteCommand(@"INSERT INTO Inscrieri(concurs, participant) VALUES (@cId, @pId)", connection))
            {
                command.Parameters.AddWithValue("@cId", cId);
                command.Parameters.AddWithValue("@pId", pId);
                var result = command.ExecuteNonQuery();
                if (result <= 0)
                {
                    Log.Error("Did not enroll anything!");
                    return;
                }
                Log.Info("Enrolled!");
            }
        }
        
    }
}