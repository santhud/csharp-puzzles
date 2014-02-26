namespace MyBoardGame.Core
{
    internal class MoveSCommand : ICommand
    {
        public Board UpdatedBoard { get; private set; }

        public void Execute(Board presentBoard)
        {
            if (presentBoard.Peg.YPos - 1 >= 0)
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos - 1, "S");
            }
            else
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "S");
            }
        }
    }
}