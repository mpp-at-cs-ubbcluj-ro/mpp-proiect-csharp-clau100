using log4net;
using MPP_CSharp.Repository;

namespace MPP_CSharp.Tests
{
    public class TestUserRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestUserRepo));
        public static bool TestAll()
        {
            var users = new UserRepo(true);
            var ok = TestGetAll(users);
            ok &= TestFind(users);
            ok &= TestCheckUser(users);
            return ok;
        }

        private static bool TestGetAll(UserRepo users)
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
                Log.Error("GetAll does not work!");
                return false;
            }

            return true;
        }

        private static bool TestFind(UserRepo users)
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
                Log.Error("Find does not work!");
                return false;
            }

            return true;
        }

        private static bool TestCheckUser(UserRepo users)
        {
            try
            {
                bool ok = users.CheckUser("claudiu", "ubb123");
                if (!ok)
                {
                    throw new TestingException();
                }
            }
            catch (TestingException)
            {
                Log.Error("CheckUser does not work!");
                return false;
            }

            return true;
        }
    }
}