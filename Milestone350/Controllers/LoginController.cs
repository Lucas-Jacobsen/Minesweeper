using Microsoft.AspNetCore.Mvc;
using Milestone350.Models;
using Milestone350.Services;

namespace Milestone350.Controllers
{
    public class LoginController : Controller
    { 
        
        //create a list of buttons
        Random random = new Random();
       static Board gameBoard = new Board();
        static Cell[,] buttons;



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
                return View("LoginSuccess", new Board());
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
            buttons = board.Grid;


           
            gameBoard.setupBombs();
            gameBoard.CalcLiveNeighbors();
            return View("DisplayBoard", gameBoard);
        }
        public IActionResult HandleButtonClick(Cell userCell)
        {
            for (int i = 0; i < gameBoard.Size; i++)
            {
                for (int j = 0; j < gameBoard.score; j++)
                {
                    if (i ==userCell.Row && j == userCell.Col)
                    {
                        gameBoard.leftClick(i, j);

                    }
                }
            }
                //if (gameBoard.checkForWin())
                //{
                //    Console.WriteLine("You have won...");
                //    return View("MinesweeperWin", gameBoard);
                //}
                //else if (gameBoard.checkForLose())
                //{
                //    return View("MinesweeperLose", gameBoard);
                //}
                //else
                {
                    return PartialView("ShowOneCell", gameBoard);
                }
            }

        public IActionResult HandleFlagClick(Cell userCell)
        {
            for (int i = 0; i < gameBoard.Size; i++)
            {
                for (int j = 0; j < gameBoard.score; j++)
                {
                    if (i == userCell.Row && j == userCell.Col)
                    {
                        gameBoard.rightClick(i, j);

                    }
                }
            }
            //if (gameBoard.checkForWin())
            //{
            //    Console.WriteLine("You have won...");
            //    return View("MinesweeperWin", gameBoard);
            //}
            //else if (gameBoard.checkForLose())
            //{
            //    return View("MinesweeperLose", gameBoard);
            //}
            //else
            {
                return PartialView("ShowOneCell", gameBoard);
            }
        }
        public IActionResult ShowOneCell(Cell userCell)
        {
            gameBoard.leftClick(userCell.Row, userCell.Col);
            
            return PartialView(gameBoard);
        }

        //button handlers for the minesweeper game page
        public IActionResult RightClickShowOneCell(Cell userCell)
        {
            gameBoard.rightClick(userCell.Row, userCell.Col);

            return PartialView("ShowOneCell", gameBoard);
        }
    }
}
