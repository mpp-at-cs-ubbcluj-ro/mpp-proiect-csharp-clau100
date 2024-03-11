using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public interface InMemoryRepo<T> where T : Entity<U> where U : new ( )
    {
		//TODO add optionals
        T[] getAll();
        T find(long id);
        T delete(long id);
        T add(T toAdd);
        T update(T toUpdate);
    }
}