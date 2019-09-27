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

        public bool addNewItem(BehaviorPageTow behaviorPageTow)
        {
            return true;
        }

        public bool delete(long Id)
        {
            return true;
        }

        public bool Edit(long id)
        {
            return true;
        }

        public bool EditBPT(BehaviorPageTow bPT)
        {
            return true;
        }

        public IEnumerable<BehaviorPageTow> GetAllBehaviorPageTows()
        {
            return _behaviorPageTows.ToList();
        }

        public IEnumerable<BehaviorPageTow> GetBehaviorPageTows(long Id)
        {
            return _behaviorPageTows.ToList().Where(d=>d.BPOId==Id);
        }

        public BehaviorPageTow GetById(long Id)
        {
            return _behaviorPageTows.FirstOrDefault(d => d.Id == Id);
        }
    }
}
