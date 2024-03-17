namespace MPP_CSharp.Domain
{
    public class Entity<T>
    {
        protected Entity(T id)
        {
            Id = id;
        }

        public T Id { get; }
    }
}