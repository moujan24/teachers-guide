using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeachersGuide.Models;
using TeachersGuide.ViewModels;


namespace TeachersGuide.Contrillers
{
    public class ClientController : Controller
    {
        private readonly IBehaviorPageTowRepository _behaviorPageTowRepository;
        private readonly IBehaviourPageOneRepository _behaviourPageOneRepository;
        private IInterventionsModifiedRepository _interventionsModifiedRepository;      //NOT READONLY !!
        public ClientController(IBehaviorPageTowRepository behaviorPageTowRepository, IBehaviourPageOneRepository behaviourPageOneRepository, IInterventionsModifiedRepository interventionsModifiedRepository)
        {
        
            _behaviorPageTowRepository = behaviorPageTowRepository;
            _behaviourPageOneRepository = behaviourPageOneRepository;
            _interventionsModifiedRepository = interventionsModifiedRepository;
            //_interventionsRepository = interventionsRepository;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Page()
        {
            return View();
        }
        // :GET: /Teacher/AddInterventions

        public IActionResult AddInterventions()
        {
            //var interventionsModifiedRepository = interventionsModifiedRepository.addNewIntervention(title, interventionKey, description, articleLink);
            IEnumerable<InterventionsModified> _iM = _interventionsModifiedRepository.GetAll();
            return View(_iM);
        }

        // :GET :/Teacher/CreateNewIntervention

        public IActionResult CreateNewIntervention()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewIntervention(InterventionsModified interventionsModified)
        {

            Console.Write("this is the post function");
            try
            {
                if (ModelState.IsValid)
                {
                    Console.Write("Model is valid");
                    Console.Write(interventionsModified.BPTid);
                    _interventionsModifiedRepository.addNewIntervention(interventionsModified);
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            InterventionsModified iM = _interventionsModifiedRepository.getId(id);
            return View(iM);
        }

        [HttpPost]
        public IActionResult Edit(InterventionsModified interventionsModified)
        {
            _interventionsModifiedRepository.edit(interventionsModified);
            return View(interventionsModified);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            InterventionsModified iM = _interventionsModifiedRepository.getId(id);
            return View(iM);
        }

        [HttpPost]
        public IActionResult Delete(InterventionsModified interventionsModified)
        {
            _interventionsModifiedRepository.delete(interventionsModified.id);
            IEnumerable<InterventionsModified> _iM = _interventionsModifiedRepository.GetAll();
            return RedirectToAction("AddInterventions");
        }
    }
}