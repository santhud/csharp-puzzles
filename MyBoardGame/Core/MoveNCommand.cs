namespace MyBoardGame.Core
{
    internal class MoveNCommand : ICommand
    {
        public Board UpdatedBoard { get; private set; }
        public void Execute(Board presentBoard)
        {
            if (presentBoard.Peg.YPos + 1 < presentBoard.Size)
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos + 1, "N");
            }
            else
            {
                this.UpdatedBoard = new Board(presentBoard.Size, presentBoard.Peg.XPos, presentBoard.Peg.YPos, "N");
            }
        }
    }
}