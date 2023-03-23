namespace Milestone350.Models
{
    public class CellModel
    {
        //Lots will need to be added to this class/ here is just the basics for printing out the board

        public int Id { get; set; }
        public int CellState { get; set; }

        public CellModel(int id, int cellState)
        {
            Id = id;
            //init cell state to 0 for the base minesweeper
            CellState = 0;
        }
    }
}
