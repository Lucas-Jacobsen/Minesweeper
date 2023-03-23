using Microsoft.AspNetCore.Mvc;
using Milestone350.Models;
using Milestone350.Services;

namespace Milestone350.Controllers
{
    public class LoginController : Controller
    { 
        
        //create a list of buttons
        static List<CellModel> buttons = new List<CellModel>();
        Random random = new Random();
        const int GRID_SIZE = 25;



        public IActionResult Index()
        {
            return View();
        }

        //method to process the user entering the login form
        public IActionResult ProcessLogin(UserModel user)
        {
            SecurityService securityService = new SecurityService();


            if (securityService.IsValid(user))
            {//when page loads, generate the board class
                for (int i = 0; i < GRID_SIZE; i++)
                {
            }
            else
            {
                return View("LoginFailure", user);
            }
        }

        //method to process the user submitting the sign up form
        public IActionResult ProcessSignup(UserModel user)
        {
            return View();
        }

        //signup results pages
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

        //button handlers for the minesweeper game page
        public IActionResult HandleButtonClick(string cellNumber)
        {
            //convert from a string into an int
            int cN = int.Parse(cellNumber);

            //change the button visual
            //THIS WILL CHANGE WITH FUNCTIONALITY
            buttons.ElementAt(cN).CellState = (buttons.ElementAt(cN).CellState + 1)%2;

            //redisplay the buttons
            return View("DisplayBoard", buttons);
        }
    }
}
