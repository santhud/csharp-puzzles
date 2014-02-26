namespace MyBoardGame.Core
{
    internal class MoveECommand : ICommand
    {
        public Board UpdatedBoard { get; private set; }
        public void Execute(Board presentBoard)
        {
            if (presentBoard.Peg.XPos + 1 < presentBoard.Size)
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos + 1, presentBoard.Peg.YPos, "E");
            }
            else
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "E");
            }
        }
    }
}