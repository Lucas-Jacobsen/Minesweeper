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
        Board gameBoard = new Board();
        



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
            
            gameBoard = new Board(board.Size, board.Difficulty);
            gameBoard.setupBombs();
            gameBoard.CalcLiveNeighbors();
            //when page loads, generate the board class
            for (int i = 0; i < gameBoard.Size; i++)
            {
                for(int j  = 0; j < gameBoard.Size; j++)
                {
                    buttons.Add(new Cell(i, j));
                }
               
            }
            return View("DisplayBoard", buttons);
        }

        public IActionResult ShowOneCell(int buttonNumber)
        {
            gameBoard.rightClick(buttons.ElementAt(buttonNumber).Row, buttons.ElementAt(buttonNumber).Col);
            
            
            
            return PartialView(buttons.ElementAt(buttonNumber));
        }

        //button handlers for the minesweeper game page
        public IActionResult RightClickShowOneCell(int buttonNumber)
        {
            gameBoard.leftClick(buttons.ElementAt(buttonNumber).Row, buttons.ElementAt(buttonNumber).Col);

            return PartialView("Flag", buttons.ElementAt(buttonNumber));
        }
    }
}
