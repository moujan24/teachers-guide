using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeachersGuide.Models;

namespace TeachersGuide.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        //private SignInManager<Users> _signManager;
        //public LoginController(SignInManager<Users> signInManager)
        //{

        //    _signManager = signInManager;
        //}
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}
        //[HttpGet]
        //public IActionResult Login(string returnUrl = "")
        //{
        //    var model = new Users(){ ReturnUrl = returnUrl };
        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Login(Users model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        //        if (result.Succeeded)
        //        {
        //            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
        //            {
        //                return Redirect(model.ReturnUrl);
        //            }
        //            else
        //            {
        //                return RedirectToAction("Client", "Page");
        //            }
        //        }
        //    }
        //    ModelState.AddModelError("", "Invalid login attempt");
        //    return View(model);
        //}
    }
}