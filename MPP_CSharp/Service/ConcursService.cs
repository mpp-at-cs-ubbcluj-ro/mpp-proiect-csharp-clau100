using System.Collections.Generic;
using log4net;
using MPP_CSharp.Domain;
using MPP_CSharp.Repository;
using Spring.Validation;

namespace MPP_CSharp.Service
{
    public class ConcursService
    {
        private  IConcursRepo ConcursRepo { get; set; }
        public IValidator Validator { get; set; }
        private static readonly ILog Log = LogManager.GetLogger(typeof(ConcursService));

        public List<Concurs> GetAll()
        {
            return ConcursRepo.GetAll();
        }

        public Concurs Find(long id)
        {
            return ConcursRepo.Find(id);
        }

        public IEnumerable<Concurs> FindAllForAge(int age)
        {
            return ConcursRepo.FindAllForAge(age);
        }

        public void Inregistreaza(long cId, long pId)
        {
            ConcursRepo.Inregistreaza(cId, pId);
        }
    }
}