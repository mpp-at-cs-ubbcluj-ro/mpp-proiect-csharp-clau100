using System.Collections.Generic;

namespace MPP_CSharp.Domain
{
    public class Participant : Entity<long> 
    {
        public int Varsta { get; }

        public List<long> Concursuri { get; set; }

        public Participant(long id, int varsta, List<long> concursuri) : base(id)
        {
            Varsta = varsta;
            Concursuri = concursuri;
        }
    }
}