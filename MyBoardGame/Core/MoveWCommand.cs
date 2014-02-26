namespace MyBoardGame.Core
{
    internal class MoveWCommand : ICommand
    {
        public Board UpdatedBoard { get; private set; }

        public void Execute(Board presentBoard)
        {
            if (presentBoard.Peg.XPos - 1 >= 0)
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos - 1, presentBoard.Peg.YPos, "W");
            }
            else
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "W");
            }
        }
    }
}