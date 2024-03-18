using System.Collections.Generic;
using MPP_CSharp.Domain;

namespace MPP_CSharp.Repository
{
    public interface IParticipantRepo : IRepo<Participant, long>
    {
        IEnumerable<Participant> FindAllFromList(IEnumerable<long> participantIDs);
    }
}