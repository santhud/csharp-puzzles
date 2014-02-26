namespace MyBoardGame.Core
{
    internal class TurnLeftCommand : ICommand
    {
        public Board UpdatedBoard { get; private set; }
        public void Execute(Board presentBoard)
        {
            if (presentBoard.Peg.Direction.Equals("N"))
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "W");
            }
            else if (presentBoard.Peg.Direction.Equals("W"))
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "S");
            }
            else if (presentBoard.Peg.Direction.Equals("S"))
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "E");
            }
            else
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "N");
            }
        }
    }
}