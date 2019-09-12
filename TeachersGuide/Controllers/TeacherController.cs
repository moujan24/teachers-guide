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
        private readonly IBehaviorPageTowRepository _behaviorPageTowRepository;
        private readonly IBehaviourPageOneRepository _behaviourPageOneRepository;
        //private readonly IInterventionsRepository _interventionsRepository;
        public TeacherController(IBehaviorPageTowRepository behaviorPageTowRepository, IBehaviourPageOneRepository behaviourPageOneRepository/*, IInterventionsRepository interventionsRepository*/)
        {
            _behaviorPageTowRepository = behaviorPageTowRepository;
            _behaviourPageOneRepository = behaviourPageOneRepository;
            //_interventionsRepository = interventionsRepository;
        }
        public IActionResult Primary()
        {
            IEnumerable<BehaviourPageOne> _bPO = _behaviourPageOneRepository.GetAll();
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
        public IActionResult Secondary_B()
        {
            return View(2);
        }
    }
}