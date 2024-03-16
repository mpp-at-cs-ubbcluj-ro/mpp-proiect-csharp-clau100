using System.Collections.Generic;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public interface IRepo<T, in TT> where T : Entity<TT> where TT : new ( )
    {
        List<T> GetAll();
        T Find(TT id);
        void Delete(TT id);
        void Add(T toAdd);
        void Update(T toUpdate);
    }
}