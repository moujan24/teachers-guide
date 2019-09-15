﻿using System;
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
        private IInterventionsModifiedRepository _interventionsModifiedRepository;      //NOT READONLY !!
        //private readonly IInterventionsRepository _interventionsRepository;
        public TeacherController(IBehaviorPageTowRepository behaviorPageTowRepository, IBehaviourPageOneRepository behaviourPageOneRepository, IInterventionsModifiedRepository interventionsModifiedRepository)
        {
            _behaviorPageTowRepository = behaviorPageTowRepository;
            _behaviourPageOneRepository = behaviourPageOneRepository;
            _interventionsModifiedRepository = interventionsModifiedRepository;
            //_interventionsRepository = interventionsRepository;
        }

        // :GET: /Teacher/Primary

        public IActionResult Primary()
        {
            IEnumerable<BehaviourPageOne> _bPO = _behaviourPageOneRepository.GetAll();
            var teacherViewModel=new TeacherViewModel() {

                bPO = _bPO.ToList()
            };
            return View(teacherViewModel);
        }

        // :GET: /Teacher/Secondary_A

        public IActionResult Secondary_A(long id)
        {
            IEnumerable<BehaviorPageTow> _bPT = _behaviorPageTowRepository.GetBehaviorPageTows(id);
            var teacherViewModel = new TeacherViewModel()
            {

                bPT = _bPT.ToList()
            };
            return View(teacherViewModel);
        }

        // :GET: /Teacher/Secondary_B

        public IActionResult Secondary_B()
        {
            return View(2);
        }

        // :GET: /Teacher/Intervention

        public IActionResult Intervention()
        {
            IEnumerable<InterventionsModified> _iM = _interventionsModifiedRepository.GetAll();
            var teacherViewModel = new TeacherViewModel()
            {
                iM = _iM.ToList()
            };
            return View(teacherViewModel);
        }
        
    }
}