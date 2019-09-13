using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersGuide.Models;

namespace TeachersGuide.ViewModels
{
    public class TeacherViewModel
    {
        public IEnumerable<BehaviourPageOne> bPO { get; set; }
        public IEnumerable<BehaviorPageTow> bPT { get; set; }
        public IEnumerable<InterventionsModified> iM { get; set; }
    }
}
