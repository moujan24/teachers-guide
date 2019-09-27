using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public interface IBehaviorPageTowRepository
    {
        IEnumerable<BehaviorPageTow> GetBehaviorPageTows(long Id);
        IEnumerable<BehaviorPageTow> GetAllBehaviorPageTows();
        bool Edit(long id);
        bool EditBPT(BehaviorPageTow bPT);
        BehaviorPageTow GetById(long Id);
        bool delete(long Id);
        bool addNewItem(BehaviorPageTow behaviorPageTow);
    }
}
