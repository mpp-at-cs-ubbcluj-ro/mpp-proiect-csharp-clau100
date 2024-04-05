using System.Linq;
using log4net;
using MPP_CSharp.Repository;

namespace MPP_CSharp.Tests
{
    public class TestConcursRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestConcursRepo));

        public static void TestAll()
        {
            var concursuri = new ConcursRepo(true);
            TestGetAll(concursuri);
            TestFind(concursuri);
            TestFindAllForAge(concursuri);
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

                foreach (var c in all)
                {
                    switch (c.Id)
                    {
                        case 1 when c.Participanti[0] != 1:
                            throw new TestingException();
                        case 2 when c.Participanti[0] != 2:
                            throw new TestingException();
                    }
                }
            }
            catch (TestingException)
            {
                throw new TestingException("GetAll does not work!");
            }
            return true;
        }

        private static void TestFind(ConcursRepo concursuri)
        {
            try
            {
                var concurs = concursuri.Find(2);
                if (concurs.Id != 2 || concurs.Proba != "Dans" || concurs.VarstaMin != 12 || concurs.VarstaMax != 14 || concurs.Participanti[0] != 2)
                {
                    throw new TestingException();
                }
            }
            catch (TestingException)
            {
                throw new TestingException("Find does not work");
            }
        }

        private static void TestFindAllForAge(IConcursRepo concursuri)
        {
            try
            {
                var all = concursuri.FindAllForAge(12);
                if (all.Count() != 2)
                {
                    throw new TestingException();
                }
            }
            catch (TestingException)
            {
                throw new TestingException("FindAllForAge does not work!");
            }
        }
    }
}