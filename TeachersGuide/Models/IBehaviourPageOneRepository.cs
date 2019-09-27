using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeachersGuide.Models
{
    public interface IBehaviourPageOneRepository
    {
        IEnumerable<BehaviourPageOne> GetAll();
        BehaviourPageOne GetById(long Id);
        bool edit(BehaviourPageOne behaviourPageOne);
        bool delete(long Id);
        bool addNewItem(BehaviourPageOne behaviourPageOne);
    }
}
