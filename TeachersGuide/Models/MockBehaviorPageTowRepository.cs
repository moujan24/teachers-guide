using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public class MockBehaviorPageTowRepository : IBehaviorPageTowRepository
    {
        private List<BehaviorPageTow> _behaviorPageTows;
        public MockBehaviorPageTowRepository()
        {

        }
        public IEnumerable<BehaviorPageTow> GetBehaviorPageTows(long Id)
        {
            return _behaviorPageTows.ToList().Where(d=>d.BPOId==Id);
        }
    }
}
