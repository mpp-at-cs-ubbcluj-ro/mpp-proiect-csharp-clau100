using System.Collections.Generic;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Repository;
using Spring.Validation;

namespace MPP_CSharp.Service
{
    public class UserService
    {
        private IUserRepo UserRepo { get; set; }
        public IValidator Validator { get; set; }

        private static readonly ILog Log = LogManager.GetLogger(typeof(UserService));
        public List<User> GetAll()
        {
            return UserRepo.GetAll();
        }

        public User Find(long id)
        {
            return UserRepo.Find(id);
        }

        public bool CheckUser(User u)
        {
            if (!Validator.Validate(u, new ValidationErrors()))
            {
                Log.Error("Provided User is not a valid user!");
            }
            return UserRepo.CheckUser(u);
        }
        
    }
}