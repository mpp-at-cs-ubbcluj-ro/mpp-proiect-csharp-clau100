using System.Collections.Generic;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public interface IConcursRepo : IRepo<Concurs, long>
    {
        IEnumerable<Concurs> FindAllForAge(int age);
        
    }
}