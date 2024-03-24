using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class ParticipantRepo : BdRepo, IParticipantRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ParticipantRepo));

        public ParticipantRepo(bool testing) : base(testing)
        {
            Log.Info("Inizializing new ParticipantRepo...");
        }
        
        public List<Participant> GetAll()
        {
            var arr = new List<Participant>();
            Log.Info("Fetching all Participanti from DB");
            var connection = GetConnection();
            using (var command = new SQLiteCommand("SELECT * FROM Participant p INNER JOIN Inscrieri I on p.id = i.participant", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(reader.GetOrdinal("id"));
                        var varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                        var concurs = reader.GetInt64(reader.GetOrdinal("concurs"));
                        var found = false;
                        for (int i = 0; i < arr.Count; i++)
                        {
                            if (arr[i].Id != id) continue;
                            var newLst = arr[i].Concursuri;
                            newLst.Add(concurs);
                            arr[i].Concursuri = newLst;
                            found = true;
                        }

                        if (found) continue;
                        var lst = new List<long>();
                        lst.Add(concurs);
                        var p = new Participant(id, varsta, lst);
                        arr.Add(p);
                        Log.Info("Found participant with id="+id+" and concurs with id="+concurs);
                    }
                }
            }
            return arr;
        }

        public Participant Find(long id)
        {
            Log.Info("Trying to find Participant with id="+id);
            var connection = GetConnection();
            using (var command = new SQLiteCommand(@"SELECT * FROM Participant p INNER JOIN Inscrieri I on p.id = i.participant where p.id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    Participant p = null;
                    while (reader.Read())
                    {
                        var varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                        var concurs = reader.GetInt64(reader.GetOrdinal("concurs"));
                        if (p is null)
                        {
                            p = new Participant(id, varsta, new List<long>());
                        }
                        var newLst = p.Concursuri;
                        newLst.Add(concurs);
                        p.Concursuri = newLst;
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
            Log.Info("Trying to find all Participant from list");
            var lst = new List<Participant>();
            var connection = GetConnection();
            foreach (var id in participantIDs)
            {
                Log.Info("Trying to find Participant with id="+id);
                lst.Add(Find(id));
            }
            return lst;
        }
    }
}