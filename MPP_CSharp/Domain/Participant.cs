namespace MPP_CSharp.Domain
{
    public class Participant : Entity<long> 
    {
        public int Varsta { get; }

        public long[] Concursuri { get; set; }

        public Participant(long id, int varsta, long[] concursuri) : base(id)
        {
            Varsta = varsta;
            Concursuri = concursuri;
        }
    }
}