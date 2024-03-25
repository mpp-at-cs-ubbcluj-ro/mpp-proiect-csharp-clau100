using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using log4net;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public class ParticipantRepo : BdRepo, IParticipantRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ParticipantRepo));

        public ParticipantRepo(bool testing = false) : base(testing)
        {
            Log.Info("Inizializing new ParticipantRepo...");
        }
        
        public List<Participant> GetAll()
        {
            var arr = new List<Participant>();
            Log.Info("Fetching all Participanti from DB");
            var connection = GetConnection();
            using (var command = new SQLiteCommand("SELECT * FROM Participant p LEFT JOIN Inscrieri I on p.id = i.participant", connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(reader.GetOrdinal("id"));
                        var varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                        var nume = reader.GetString(reader.GetOrdinal("Nume"));
                        long concurs = 0;
                        try
                        {
                            concurs = reader.GetInt64(reader.GetOrdinal("concurs"));
                        }
                        catch (InvalidCastException ){}

                        var found = false;
                        if (concurs == 0)
                        {
                            arr.Add(new Participant(id, varsta, nume, new List<long>()));
                            continue;
                        }
                        foreach (var t in arr.Where(t => t.Id == id))
                        {
                            t.Concursuri.Add(concurs);
                            found = true;
                        }

                        if (found) continue;
                        var lst = new List<long> { concurs };
                        var p = new Participant(id, varsta, nume,lst);
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
            using (var command = new SQLiteCommand(@"SELECT * FROM Participant p LEFT JOIN Inscrieri I on p.id = i.participant where p.id = @id", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                using (var reader = command.ExecuteReader())
                {
                    Participant p = null;
                    while (reader.Read())
                    {
                        var varsta = reader.GetInt32(reader.GetOrdinal("Varsta"));
                        var concurs = reader.GetInt64(reader.GetOrdinal("concurs"));
                        var nume = reader.GetString(reader.GetOrdinal("Nume"));
                        if (p is null)
                        {
                            p = new Participant(id, varsta, nume, new List<long>());
                        }
                        p.Concursuri.Add(concurs);
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
            Log.Info("Trying to add a Participant");
            var connection = GetConnection();
            using (var command = new SQLiteCommand(@"INSERT INTO Participant(Nume, Varsta) VALUES (@Nume, @Varsta)", connection))
            {
                command.Parameters.AddWithValue("@Nume", toAdd.Nume);
                command.Parameters.AddWithValue("@Varsta", toAdd.Varsta);
                var result = command.ExecuteNonQuery();
                if (result <= 0)
                {
                    Log.Error("Could not add Participant");
                    return;
                }
                Log.Info("Added Participant");
            }
        }

        public void Update(Participant toUpdate)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Participant> FindAllFromList(IEnumerable<long> participantIDs)
        {
            Log.Info("Trying to find all Participant from list");
            var lst = new List<Participant>();
            foreach (var id in participantIDs)
            {
                Log.Info("Trying to find Participant with id="+id);
                lst.Add(Find(id));
            }
            return lst;
        }
    }
}