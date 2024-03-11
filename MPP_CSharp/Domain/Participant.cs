namespace MPP_CSharp.Domain
{
    public class Participant : Entity<Long> 
    {
        public int Varsta => varsta;

        public long[] Concursuri
        {
            get => concursuri;
            set => concursuri = value;
        }

        private int varsta;
        private long[] concursuri;
    }
}