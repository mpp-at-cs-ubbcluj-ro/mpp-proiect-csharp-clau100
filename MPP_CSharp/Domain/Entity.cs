namespace MPP_CSharp.Domain
{
    public class Entity<T>
    {
        private T id;
        public T Id => id;
        public T getId()
        {
            return id;
        }
    }
}