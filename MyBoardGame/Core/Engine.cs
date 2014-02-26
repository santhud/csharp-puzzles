using System.Linq;

namespace MyBoardGame.Core
{
    public class Engine
    {
        private ICommand command;

        internal Board InitWithGivenPos(int boardSize, int x, int y, string dir)
        {
            return new Board(boardSize, x, y, dir);
        }

        public Board Init(int size)
        {
            return new Board(size, 0, 0, "N");
        }

        private static ICommand GetCommand(char key)
        {
            if (key.Equals('E')) return new MoveECommand();
            if (key.Equals('W')) return new MoveWCommand();
            if (key.Equals('N')) return new MoveNCommand();
            if (key.Equals('S')) return new MoveSCommand();
            if (key.Equals('L')) return new TurnLeftCommand();
            return new TurnRightCommand();
        }

        public Board PerformCommand(Board presentBoard, char key)
        {
            command = GetCommand(key == 'M' ? presentBoard.Peg.Direction[0] : key);
            command.Execute(presentBoard);
            return command.UpdatedBoard;
        }

        public Board ProcessInputSequence(string inputCommands, Board inputBoard)
        {
            return inputCommands.Aggregate(inputBoard, PerformCommand);
        }
    }
}
