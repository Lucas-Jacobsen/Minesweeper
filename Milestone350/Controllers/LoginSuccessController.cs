using Microsoft.AspNetCore.Mvc;
using Milestone350.Models;

namespace Milestone350.Controllers
{
    public class LoginSuccessController : Controller
    {
        //create a list of buttons
        static List<CellModel> buttons = new List<CellModel>();
        Random random = new Random();
        const int GRID_SIZE = 25;

        
        public IActionResult Index()
        {
            //when page loads, generate the board class
            for (int i = 0; i< GRID_SIZE; i++)
            {

                buttons.Add(new CellModel(i, random.Next(2)));
            }
            return View("DisplayBoard", buttons);
        }
    }
}
