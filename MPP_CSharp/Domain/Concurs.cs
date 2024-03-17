namespace MPP_CSharp.Domain
{
    public class Concurs : Entity<long>
    {
        public Concurs(long id, string proba, int varstaMin, int varstaMax, long[] participanti) : base(id)
        {
            Proba = proba;
            VarstaMin = varstaMin;
            VarstaMax = varstaMax;
            Participanti = participanti;
        }

        public string Proba { get; }

        public int VarstaMin { get; }

        public int VarstaMax { get; }

        public long[] Participanti { get; set; }
    }
}