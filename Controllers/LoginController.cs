using Microsoft.AspNetCore.Mvc;
using NLog;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Utility;
using Microsoft.AspNetCore.Http;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            //MyLogger.GetInstance().Info("Entering the ProcessLogin method.");
            //MyLogger.GetInstance().Info("Parameter: " + user.ToString());

            SecurityService securityService = new SecurityService();

            if (securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Login success.");

                // Remember who is logged in
                HttpContext.Session.SetString("username", user.UserName);

                //MyLogger.GetInstance().Info("Leaving the ProcessLogin method.");
                return View("LoginSuccess", user);
            }
            else
            {
                MyLogger.GetInstance().Info("Login failure.");
                //MyLogger.GetInstance().Info("Leaving the ProcessLogin method.");

                // Cancel any existing valid login
                HttpContext.Session.Remove("username");
                return View("LoginFailure", user);
            }
        }

        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content("I am a protected method if the proper attribute is applied to me.");
        }
    }
}
