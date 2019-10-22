using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeachersGuide.Models;

namespace TeachersGuide.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsersRepository usersRepository;
        public IActionResult Login()
        {
            return View();
        }
        
        //private SignInManager<Users> _signManager;
        public LoginController(IUsersRepository _usersRepository)
        {
            usersRepository = _usersRepository;
        }
      
        //[HttpGet]
        //public IActionResult Login(string returnUrl = "")
        //{
        //    var model = new Users(){ ReturnUrl = returnUrl };
        //    return View(model);
        //}
        [HttpPost]
        public async Task<IActionResult> Login(Users model)
        {
            if (ModelState.IsValid)
            {
                //var result = await _signManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                //if (result.Succeeded)
                //{
                //  if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                //{
                //    return Redirect(model.ReturnUrl);
                //}
                //else  
                //{
                        //bool x= usersRepository.verifyUser(model);
                        return RedirectToAction("Page", "Client");
                    //}
                //}
            }
            //ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
    }
}