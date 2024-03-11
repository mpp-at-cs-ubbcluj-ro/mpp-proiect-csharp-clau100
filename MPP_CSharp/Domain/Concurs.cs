namespace MPP_CSharp.Domain
{
    public class Concurs : Entity<long>
    {
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