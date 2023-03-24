using Microsoft.AspNetCore.Mvc;
using Milestone350.Models;
using Milestone350.Services;

namespace Milestone350.Controllers
{
    public class LoginController : Controller
    { 
        
        //create a list of buttons
        static List<Cell> buttons = new List<Cell>();
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
            {
                //when page loads, generate the board class
                return View("LoginSuccess", new Board());
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

  public IActionResult DisplayGameBoard(Board board)
        {

            //when page loads, generate the board class
            for (int i = 0; i < board.Size * board.Size; i++)
            {

                buttons.Add(new Cell(i, random.Next(2)));
            }
            return View("DisplayBoard", buttons);
        }

      

        //button handlers for the minesweeper game page
        public IActionResult RightClickFlag(int buttonNumber)
        {
            buttons.ElementAt(buttonNumber).IsFlagged = true;

            return PartialView("Flag", buttons.ElementAt(buttonNumber));
        }
    }
}
