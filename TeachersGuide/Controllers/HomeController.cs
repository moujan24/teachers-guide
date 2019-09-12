using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeachersGuide.Contrillers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Feedback()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
       
        public IActionResult About_Guide()
        {
            return View();
        }
    }
}