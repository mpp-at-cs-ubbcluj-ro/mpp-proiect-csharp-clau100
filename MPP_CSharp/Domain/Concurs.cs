namespace MPP_CSharp.Domain
{
    public class Concurs : Entity<long>
    {
        public Concurs(long id, string proba, int varstaMin, int varstaMax, int numarParticipanti, long[] participanti) : base(id)
        {
            this.proba = proba;
            this.varstaMin = varstaMin;
            this.varstaMax = varstaMax;
            this.numarParticipanti = numarParticipanti;
            this.participanti = participanti;
        }

        public string Proba => proba;

        public int VarstaMin => varstaMin;

        public int VarstaMax => varstaMax;

        public int NumarParticipanti => numarParticipanti;

        public long[] Participanti
        {
            get => participanti;
            set => participanti = value;
        }
    
        private string proba;
        private int varstaMin;
        private int varstaMax;
        private int numarParticipanti;
        private long[] participanti;
    }
}