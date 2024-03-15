using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public interface IInMemoryRepo<T, TT> where T : Entity<TT> where TT : new ( )
    {
		//TODO add optionals
        T[] GetAll();
        T Find(long id);
        T Delete(long id);
        T Add(T toAdd);
        T Update(T toUpdate);
    }
}