namespace MyBoardGame.Core
{
    internal class TurnRightCommand : ICommand
    {
        public Board UpdatedBoard { get; private set; }
        public void Execute(Board presentBoard)
        {
            if (presentBoard.Peg.Direction.Equals("N"))
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "E");
            }
            else if (presentBoard.Peg.Direction.Equals("E"))
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "S");
            }
            else if (presentBoard.Peg.Direction.Equals("S"))
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "W");
            }
            else
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "N");
            }
        }
    }
}
