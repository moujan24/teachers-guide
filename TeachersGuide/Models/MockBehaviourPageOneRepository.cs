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
        public IEnumerable<BehaviourPageOne> GetAll()
        {
            return _behaviourPageOnes.ToList();
        }
    }
}
