using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class MockBehaviourPageOneRepository : IBehaviourPageOneRepository
    {
        private List<BehaviourPageOne> _behaviourPageOnes;
        public MockBehaviourPageOneRepository()
        {

        }

        public bool addNewItem(BehaviourPageOne behaviourPageOne)
        {
            return true;
        }

        public bool delete(long Id)
        {
            return true;
        }

        public bool edit(BehaviourPageOne behaviourPageOne)
        {
            return true;
        }

        public IEnumerable<BehaviourPageOne> GetAll()
        {
            return _behaviourPageOnes.ToList();
        }

        public BehaviourPageOne GetById(long Id)
        {
            return _behaviourPageOnes.FirstOrDefault(d=>d.Id==Id);
        }
    }
}
