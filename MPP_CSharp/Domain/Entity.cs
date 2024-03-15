namespace MPP_CSharp.Domain
{
    public class Entity<T>
    {
        private T id;

        public Entity(T id)
        {
            this.id = id;
        }

        public T Id => id;
    }
}