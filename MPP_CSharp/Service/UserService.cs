using System.Collections.Generic;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Repository;
using Spring.Validation;

namespace MPP_CSharp.Service
{
    public class UserService
    {
        private readonly IUserRepo _userRepo = new UserRepo();

        public IValidator Validator { get; set; }

        private static readonly ILog Log = LogManager.GetLogger(typeof(UserService));
        public List<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public User Find(long id)
        {
            return _userRepo.Find(id);
        }

        public bool CheckUser(User u)
        {
            if (!Validator.Validate(u, new ValidationErrors()))
            {
                Log.Error("Provided User is not a valid user!");
            }
            return _userRepo.CheckUser(u);
        }
        
    }
}