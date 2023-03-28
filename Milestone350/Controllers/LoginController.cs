using Microsoft.AspNetCore.Mvc;
using Milestone350.Models;
using Milestone350.Services;

namespace Milestone350.Controllers
{
    public class LoginController : Controller
    { 
        
        //create a list of buttons
        Random random = new Random();
       public Board gameBoard = new Board();
        



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
          
            //when page loads, generate the board class
            for (int i = 0; i < gameBoard.Size; i++)
            {
                for(int j  = 0; j < gameBoard.Size; j++)
                {
                    gameBoard.Grid[i, j] = new Cell(i,j);
                }
               
            }
            gameBoard.setupBombs();
            gameBoard.CalcLiveNeighbors();
            return View("DisplayBoard", gameBoard);
        }

        public IActionResult ShowOneCell(int i, int j)
        {
            gameBoard.leftClick(i,j);
            
            
            
            return PartialView(gameBoard);
        }

        //button handlers for the minesweeper game page
        public IActionResult RightClickShowOneCell(int i, int j)
        {
            gameBoard.rightClick(i,j);

            return PartialView("ShowOneCell", gameBoard);
        }
    }
}
