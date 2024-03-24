using System.Collections.Generic;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Repository;
using Spring.Validation;

namespace MPP_CSharp.Service
{
    public class ParticipantService
    {
        private IParticipantRepo ParticipantRepo { get; set; }
        public IValidator Validator { get; set; }
        private static readonly ILog Log = LogManager.GetLogger(typeof(ParticipantService));

        public List<Participant> GetAll()
        {
            return ParticipantRepo.GetAll();
        }

        public Participant Find(long id)
        {
            return ParticipantRepo.Find(id);
        }
        
    }
}