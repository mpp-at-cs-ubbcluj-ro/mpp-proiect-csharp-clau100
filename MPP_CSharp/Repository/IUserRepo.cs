using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public interface IUserRepo : IRepo<User, long>
    {
        bool CheckUser(string username, string password);
        
    }
}