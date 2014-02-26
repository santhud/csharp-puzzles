namespace MyBoardGame.Core
{
    internal interface ICommand
    {
        Board UpdatedBoard { get; }
        void Execute(Board board);
    }
}