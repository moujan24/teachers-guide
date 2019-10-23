using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersGuide.Models;
using TeachersGuide.ViewModels;


namespace TeachersGuide.Contrillers
{
    public class ClientController : Controller
    {
        private readonly IFeedBackRepository _feedBackRepository;
        private IInterventionsModifiedRepository _interventionsModifiedRepository;      //NOT READONLY !!
        private IBehaviorPageTowRepository _behaviorPageTowRepository;
        private IBehaviourPageOneRepository _behaviourPageOneRepository;
        private static bool authenticationToken = false;
        public ClientController(IFeedBackRepository feedBackRepository,
                                IInterventionsModifiedRepository interventionsModifiedRepository,
                                IBehaviorPageTowRepository behaviorPageTowRepository,
                                IBehaviourPageOneRepository behaviourPageOneRepository)
        {
            _feedBackRepository = feedBackRepository;
            _interventionsModifiedRepository = interventionsModifiedRepository;
            _behaviorPageTowRepository = behaviorPageTowRepository;
            _behaviourPageOneRepository = behaviourPageOneRepository;

        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Page()
        {
            if (TempData["sendFlag"] != null) { 
                authenticationToken = (bool)TempData["sendFlag"];
            }
            if (authenticationToken) { 
                ViewData["stats"] = _behaviorPageTowRepository.GetAllBehaviorPageTows();
                IEnumerable<FeedBack> _feedBack = _feedBackRepository.GetAll();
                var clientViewModel = new ClientViewModel()
                {
                    feedBacks = _feedBack.ToList()
                };
                ViewData["feedback"] = _feedBack;
                return View();
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult Feedback()
        {
            if (authenticationToken) { 
                IEnumerable<FeedBack> _feedBack = _feedBackRepository.GetAll();
                var clientViewModel = new ClientViewModel()
                {

                    feedBacks = _feedBack.ToList()
                };
                return View(clientViewModel);
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult Statistics()
        {
            if (authenticationToken) { 
                IEnumerable<BehaviorPageTow> _bPT = _behaviorPageTowRepository.GetAllBehaviorPageTows();
                return View(_bPT);
            }
            else
            {
                return BadRequest();
            }
        }


        public IActionResult EditBehaviour_P1()
        {
            if (authenticationToken) { 
            IEnumerable<BehaviourPageOne> _bPO = _behaviourPageOneRepository.GetAll();
            return View(_bPO);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult Edit_BPO(long id)
        {
            if (authenticationToken) { 
            BehaviourPageOne bPO = _behaviourPageOneRepository.GetById(id);
            return View(bPO);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Edit_BPO(BehaviourPageOne bPO)
        {
            if (authenticationToken) { 
                try
                {
                    if (ModelState.IsValid)
                    {
                        _behaviourPageOneRepository.edit(bPO);
                        IEnumerable<BehaviourPageOne> _bPO = _behaviourPageOneRepository.GetAll();
                        return View("EditBehaviour_P1", _bPO);
                    }
                    else
                    {
                        return View();
                    }
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            else { return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Delete_BPO(long id)
        {
            if (authenticationToken) { 
                BehaviourPageOne bPO = _behaviourPageOneRepository.GetById(id);
                return View(bPO);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Delete_BPO(BehaviourPageOne bPO)
        {
            if (authenticationToken) { 
            _behaviourPageOneRepository.delete(bPO.Id);
            IEnumerable<BehaviourPageOne> _iM = _behaviourPageOneRepository.GetAll();
            return RedirectToAction("EditBehaviour_P1");
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult CreateNewBPO ()
        {
            if (authenticationToken) { 
                return View();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateNewBPO(BehaviourPageOne behaviourPageOne)
        {
            if (authenticationToken) { 
            try
            {
                if (ModelState.IsValid)
                {
                    _behaviourPageOneRepository.addNewItem(behaviourPageOne);
                    IEnumerable<BehaviourPageOne> _bPO = _behaviourPageOneRepository.GetAll();

                    return View("EditBehaviour_P1", _bPO);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
            }
            else { return BadRequest(); }
        }

        public IActionResult Details_BPO (long Id)
        {
            if (authenticationToken) { 
            IEnumerable<BehaviorPageTow> bPT = _behaviorPageTowRepository.GetBehaviorPageTows(Id).ToList();
            return View(bPT);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Edit_BPT(long id)
        {
            if (authenticationToken) { 
            BehaviorPageTow bPT = _behaviorPageTowRepository.GetById(id);
            return View(bPT);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Edit_BPT(BehaviorPageTow bPT)
        {
            if (authenticationToken) { 
            try
            {
                if (ModelState.IsValid)
                {
                   _behaviorPageTowRepository.EditBPT(bPT);
                    IEnumerable<BehaviorPageTow> _bPT = _behaviorPageTowRepository.GetBehaviorPageTows(bPT.BPOId).ToList();
                    return View("Details_BPO", _bPT);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Delete_BPT(long id)
        {
            if (authenticationToken) { 
            BehaviorPageTow bPT = _behaviorPageTowRepository.GetById(id);
            return View(bPT);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Delete_BPT(BehaviorPageTow bPT)
        {
            if (authenticationToken) { 
            _behaviorPageTowRepository.delete(bPT.Id);
            IEnumerable<BehaviorPageTow> _bPT = _behaviorPageTowRepository.GetBehaviorPageTows(bPT.BPOId).ToList();
            return View("Details_BPO", _bPT);
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult CreateNewBPT(long Id)
        {
            if (authenticationToken) { 
            var BPT = new BehaviorPageTow();
            BPT.BPOId = Id;
            BPT.Count = 0;
            return View(BPT);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateNewBPT(BehaviorPageTow behaviorPageTow)
        {
            if (authenticationToken) { 
            behaviorPageTow.Id = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    _behaviorPageTowRepository.addNewItem(behaviorPageTow);
                    IEnumerable<BehaviorPageTow> _bPT = _behaviorPageTowRepository.GetBehaviorPageTows(behaviorPageTow.BPOId).ToList();
                    return View("Details_BPO", _bPT);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
            }
            else
            {
                return BadRequest();
            }
        }

        
            public IActionResult Details_BPT(long Id,long data)
        {
            if (authenticationToken) { 

            ViewBag.rout = data;
            ViewBag.id = Id;
            IEnumerable<InterventionsModified> _iM = _interventionsModifiedRepository.GetCategory(Id).ToList();

            return View(_iM);
            }
            else { return BadRequest(); }
        }

        public IActionResult CreateNewIntervention(long Id, long data)
        {
            if (authenticationToken) { 
            ViewBag.rout = data;
            ViewBag.id = Id;
            ViewBag.Flag = 1;
            InterventionsModified interventionsModified = new InterventionsModified();
            interventionsModified.BPTid = Id;
            return View("CreateNewIntervention", interventionsModified);
                //return View("Details_BPT", interventionsModified);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateNewIntervention(InterventionsModified interventionsModified, long data)
        {
            if (authenticationToken) { 
            @ViewBag.rout = data;
            ViewBag.id = interventionsModified.BPTid;
            interventionsModified.id = 0;
            Console.Write("this is the post function");
            try
            {
                if (ModelState.IsValid)
                {
                    _interventionsModifiedRepository.addNewIntervention(interventionsModified);
                    ViewBag.Flag = 0;
                    return View();
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
            }
            else
            {
                return BadRequest();
            }
        }





        [HttpGet]
        public IActionResult Delete(long id, long data)
        {
            if (authenticationToken) { 
            ViewBag.rout = data;
            InterventionsModified bPT = _interventionsModifiedRepository.getId(id);
            ViewBag.id = bPT.BPTid;
            return View(bPT);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Delete(InterventionsModified bPT, long id, long data)
        {
            if (authenticationToken) { 
            ViewBag.rout = data;
            ViewBag.id = bPT.BPTid;
            _interventionsModifiedRepository.delete(bPT.id);
            InterventionsModified iM = new InterventionsModified();
            return View(iM);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult Edit(long id, long data)
        {
            if (authenticationToken) { 
            ViewBag.rout = data;
            InterventionsModified bPT = _interventionsModifiedRepository.getId(id);
            ViewBag.id = bPT.BPTid;
            ViewBag.Flag = 1;
            return View(bPT);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Edit(InterventionsModified interventionsModified, long id, long data)
        {
            if (authenticationToken)
            {
                ViewBag.rout = data;
                ViewBag.id = interventionsModified.BPTid;

                try
                {
                    if (ModelState.IsValid)
                    {
                        _interventionsModifiedRepository.edit(interventionsModified);
                        ViewBag.Flag = 0;
                        return View();
                    }
                    else
                    {
                        return View();
                    }
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IActionResult logout()
        {
            authenticationToken = false;
            return Ok();
        }
       
    }
}