using log4net;
using MPP_CSharp.Repository;

namespace MPP_CSharp.Tests
{
    public class TestParticipantRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestParticipantRepo));

        public static bool TestAll()
        {
            var participanti = new ParticipantRepo(true);
            var ok = TestGetAll(participanti);
            ok &= TestFind(participanti);
            return ok;
        }

        private static bool TestGetAll(ParticipantRepo participanti)
        {
            try
            {
                var all = participanti.GetAll();
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

        private static bool TestFind(ParticipantRepo participanti)
        {
            try
            {
                var participant = participanti.Find(1);
                if (participant.Id != 1 || participant.Varsta != 12)
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