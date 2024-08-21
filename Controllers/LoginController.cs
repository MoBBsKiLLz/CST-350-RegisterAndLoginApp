using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            if (user.UserName == "BillGates" && user.Password == "bigbucks")
            {
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFailure", user);
            }
        }
    }
}
