using System.Collections.Generic;
using System.Linq;
using log4net;
using MPP_CSharp.Repository;

namespace MPP_CSharp.Tests
{
    public class TestParticipantRepo
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TestParticipantRepo));

        public static void TestAll()
        {
            var participanti = new ParticipantRepo(true);
            TestGetAll(participanti);
            TestFind(participanti);
            TestFindFromList(participanti);
        }

        private static void TestGetAll(ParticipantRepo participanti)
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
                throw new TestingException("GetAll does not work!");
            }
        }

        private static void TestFind(ParticipantRepo participanti)
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
                throw new TestingException("TestFind does not work!");
            }
        }

        private static void TestFindFromList(IParticipantRepo participanti)
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
                throw new TestingException("FindFromList does not work!");
            }
        }
        
    }
}