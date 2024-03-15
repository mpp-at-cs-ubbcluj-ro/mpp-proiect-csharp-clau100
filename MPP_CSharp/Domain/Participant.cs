namespace MPP_CSharp.Domain
{
    public class Participant : Entity<long> 
    {
        public int Varsta => varsta;

        public long[] Concursuri
        {
            get => concursuri;
            set => concursuri = value;
        }

        public Participant(long id, int varsta, long[] concursuri) : base(id)
        {
            this.varsta = varsta;
            this.concursuri = concursuri;
        }

        private int varsta;
        private long[] concursuri;
    }
}