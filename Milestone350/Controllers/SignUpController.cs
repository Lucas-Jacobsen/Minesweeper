using Microsoft.AspNetCore.Mvc;
using Milestone350.Models;
using Milestone350.Services;

namespace Milestone350.Controllers
{
    public class SignUpController : Controller
    {
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
