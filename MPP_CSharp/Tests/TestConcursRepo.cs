using log4net;
using MPP_CSharp.Repository;

namespace MPP_CSharp.Tests
{
    public class TestConcursRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestConcursRepo));

        public static bool TestAll()
        {
            var concursuri = new ConcursRepo(true);
            var ok = TestGetAll(concursuri);
            ok &= TestFind(concursuri);
            return ok;
        }

        private static bool TestGetAll(ConcursRepo concursuri)
        {
            try
            {
                var all = concursuri.GetAll();
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

        private static bool TestFind(ConcursRepo concursuri)
        {
            try
            {
                var concurs = concursuri.Find(2);
                if (concurs.Id != 2 || concurs.Proba != "Dans" || concurs.VarstaMin != 12 || concurs.VarstaMax != 14)
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
    }
}