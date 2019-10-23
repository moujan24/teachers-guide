using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeachersGuide.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace TeachersGuide.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository usersRepository;
        
        //private SignInManager<Users> _signManager;
        public LoginController(IUsersRepository _usersRepository)
        {
            usersRepository = _usersRepository;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Users model)
        {
            if (ModelState.IsValid)
            {

                if (usersRepository.verifyUser(model)) {
                    TempData["sendFlag"] = true;
                    return RedirectToAction("Page", "Client");
                }
                else
                    return BadRequest();
            }
            return BadRequest();
        }
    }
}
