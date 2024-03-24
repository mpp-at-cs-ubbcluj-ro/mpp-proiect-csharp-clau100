using System.Collections.Generic;
using System.Linq;
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
            ok &= TestFindFromList(participanti);
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

        private static bool TestFindFromList(IParticipantRepo participanti)
        {
            var inputs = new List<long>{ 1, 2 };
            try
            {
                var found = participanti.FindAllFromList(inputs);
                if (found.Count() != 2)
                {
                    throw new TestingException();
                }
            }
            catch (TestingException)
            {
                Log.Error("FindAllFromList does not work!");
                return false;
            }

            return true;
        }
        
    }
}