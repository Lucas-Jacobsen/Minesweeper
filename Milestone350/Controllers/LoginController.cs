using Microsoft.AspNetCore.Mvc;
using Milestone350.Models;
using Milestone350.Services;

namespace Milestone350.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();


            if (securityService.IsValid(user))
            {
                return View("LoginSuccess", user);
            }
            else
            {
                return View("LoginFailure", user);
            }
        }

        public IActionResult ProcessSignup(UserModel user)
        {
            return View();
        }
        public IActionResult SignupResults(UserModel user)
        {
            SecurityService securityService = new SecurityService();

            if (securityService.IsAdded(user))
            {
                return View("SignupSuccess", user);
            }
            else
            {
                return View("SignupFailure", user);
            }
        }
    }
}
