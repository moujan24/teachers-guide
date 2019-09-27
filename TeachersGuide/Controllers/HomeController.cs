using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeachersGuide.Models;


namespace TeachersGuide.Contrillers
{
    public class HomeController : Controller
    {

        private readonly IFeedBackRepository _feedBackRepository;
        public HomeController(IFeedBackRepository feedBackRepository)
        {
            _feedBackRepository = feedBackRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Feedback(FeedBack feedBack)
        {
            feedBack.CreateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                _feedBackRepository.Submit(feedBack);
                return View("Index", feedBack);
            }
            else
            {
                return View();
            }
        }

        public IActionResult About()
        {
            return View();
        }
       
        public IActionResult About_Guide()
        {
            return View();
        }
        public IActionResult disclaimerPage()
        {
            return View();
        }
    }
}