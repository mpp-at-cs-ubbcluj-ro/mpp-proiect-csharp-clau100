using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Repository;

namespace MPP_CSharp.Tests
{
    public class TestUserRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestUserRepo));
        public static void TestAll()
        {
            var users = new UserRepo(true);
            TestGetAll(users);
            TestFind(users);
            TestCheckUser(users);
        }

        private static void TestGetAll(UserRepo users)
        {
            try
            {
                var all = users.GetAll();
                if (all.Count != 2)
                {
                    throw new TestingException();
                }
            }
            catch (TestingException)
            {
                throw new TestingException("GetAll does not work!");
            }

        }

        private static void TestFind(UserRepo users)
        {
            try
            {
                var u = users.Find(1);
                if (u.Id != 1 || u.Username != "claudiu")
                {
                    throw new TestingException();
                }
            }
            catch (TestingException)
            {
                throw new TestingException("Find does not work!");
            }
        }

        private static void TestCheckUser(IUserRepo users)
        {
            try
            {
                var ok = users.CheckUser(new User(1, "claudiu", "ubb123"));
                if (!ok)
                {
                    throw new TestingException();
                }
            }
            catch (TestingException)
            {
                throw new TestingException("CheckUser does not work!");
            }

        }
    }
}