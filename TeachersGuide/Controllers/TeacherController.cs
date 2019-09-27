using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeachersGuide.Models;
using TeachersGuide.ViewModels;

namespace TeachersGuide.Contrillers
{
    public class TeacherController : Controller
    {
        public int i;
        private readonly IBehaviorPageTowRepository _behaviorPageTowRepository;
        private readonly IBehaviourPageOneRepository _behaviourPageOneRepository;
        private IInterventionsModifiedRepository _interventionsModifiedRepository;
        //private readonly IInterventionsRepository _interventionsRepository;
        public TeacherController(IBehaviorPageTowRepository behaviorPageTowRepository, IBehaviourPageOneRepository behaviourPageOneRepository, IInterventionsModifiedRepository interventionsModifiedRepository)
        {
            _behaviorPageTowRepository = behaviorPageTowRepository;
            _behaviourPageOneRepository = behaviourPageOneRepository;
            _interventionsModifiedRepository = interventionsModifiedRepository;
            //_interventionsRepository = interventionsRepository;
            i = 0;
        }
        public int getI()
        {
            return i;
        }
        public IActionResult Primary()
        {
            IEnumerable<BehaviourPageOne> _bPO = _behaviourPageOneRepository.GetAll();
            this.i = 1;
            var teacherViewModel=new TeacherViewModel() {

                bPO = _bPO.ToList()
            };
            return View(teacherViewModel);
        }
        public IActionResult Secondary_A(long id)
        {
            IEnumerable<BehaviorPageTow> _bPT = _behaviorPageTowRepository.GetBehaviorPageTows(id);
            var teacherViewModel = new TeacherViewModel()
            {

                bPT = _bPT.ToList()
            };
            return View(teacherViewModel);
        }
        

        // :GET: /Teacher/Intervention

        public IActionResult Intervention(long id)
        {
            _behaviorPageTowRepository.Edit(id);
            IEnumerable<InterventionsModified> _iM = _interventionsModifiedRepository.GetCategory(id);
            var teacherViewModel = new TeacherViewModel()
            {
                iM = _iM.ToList()
            };
            return View(teacherViewModel);
        }

    }
}