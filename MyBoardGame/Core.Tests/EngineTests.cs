using FluentAssertions;
using NUnit.Framework;

namespace MyBoardGame.Core.Tests
{
    [TestFixture]
    public class EngineTests
    {
        const int BOARD_SIZE = 5;
        readonly Engine engine = new Engine();
        private Board myBoard;

        [SetUp]
        public void SetUp()
        {
            myBoard = engine.Init(BOARD_SIZE);
        }

        [Test]
        public void Init_Should_Return_Board_Of_Given_Size_And_A_Peg_In_Default_Position()
        {
            myBoard = engine.Init(BOARD_SIZE);

            myBoard.Size.Should().Be(BOARD_SIZE);
            myBoard.Peg.XPos.Should().Be(0);
            myBoard.Peg.YPos.Should().Be(0);
            myBoard.Peg.Direction.Should().Be("N");
        }

        [Test]
        public void MoveCommand_Should_Change_PositionOfPeg_And_Retain_Direction()
        {
            myBoard = engine.PerformCommand(myBoard, 'M');

            myBoard.Peg.XPos.Should().Be(0);
            myBoard.Peg.YPos.Should().Be(1);
            myBoard.Peg.Direction.Should().Be("N");
        }

        [TestCase(2, 2, 1)]
        [TestCase(3, 3, 2)]
        [TestCase(4, 4, 3)]
        [TestCase(5, 4, 4)]
        public void When_Facing_North_Successive_MoveCommands_Should_Change_YPositionOfPeg_And_Retain_DirectionAndXPos(int numberOfMoves, int expectedYPosition, int xpos)
        {
            myBoard = engine.InitWithGivenPos(BOARD_SIZE, xpos, 0, "N");
            while (numberOfMoves > 0)
            {
                myBoard = engine.PerformCommand(myBoard, 'M');
                numberOfMoves--;
            }

            myBoard.Peg.XPos.Should().Be(xpos);
            myBoard.Peg.YPos.Should().Be(expectedYPosition);
            myBoard.Peg.Direction.Should().Be("N");
        }

        [TestCase(2, 2, 1)]
        [TestCase(3, 1, 2)]
        [TestCase(4, 0, 3)]
        [TestCase(5, 0, 4)]
        public void When_Facing_South_Successive_MoveCommands_Should_Change_YPositionOfPeg_And_Retain_DirectionAndXPos(int numberOfMoves, int expectedYPosition, int xpos)
        {
            myBoard = engine.InitWithGivenPos(BOARD_SIZE, xpos, 4, "S");
            while (numberOfMoves > 0)
            {
                myBoard = engine.PerformCommand(myBoard, 'M');
                numberOfMoves--;
            }

            myBoard.Peg.XPos.Should().Be(xpos);
            myBoard.Peg.YPos.Should().Be(expectedYPosition);
            myBoard.Peg.Direction.Should().Be("S");
        }

        [TestCase(2, 2, 1)]
        [TestCase(3, 3, 2)]
        [TestCase(4, 4, 3)]
        [TestCase(5, 4, 4)]
        public void When_Facing_East_Successive_MoveCommands_Should_Change_XPositionOfPeg_And_Retain_DirectionAndYPos(int numberOfMoves, int expectedXPosition, int ypos)
        {
            myBoard = engine.InitWithGivenPos(BOARD_SIZE, 0, ypos, "E");
            while (numberOfMoves > 0)
            {
                myBoard = engine.PerformCommand(myBoard, 'M');
                numberOfMoves--;
            }

            myBoard.Peg.YPos.Should().Be(ypos);
            myBoard.Peg.XPos.Should().Be(expectedXPosition);
            myBoard.Peg.Direction.Should().Be("E");
        }

        [TestCase(2, 2, 1)]
        [TestCase(3, 1, 2)]
        [TestCase(4, 0, 3)]
        [TestCase(5, 0, 4)]
        public void When_Facing_West_Successive_MoveCommands_Should_Change_XPositionOfPeg_And_Retain_DirectionAndYPos(int numberOfMoves, int expectedXPosition, int ypos)
        {
            myBoard = engine.InitWithGivenPos(BOARD_SIZE, 4, ypos, "W");
            while (numberOfMoves > 0)
            {
                myBoard = engine.PerformCommand(myBoard, 'M');
                numberOfMoves--;
            }

            myBoard.Peg.YPos.Should().Be(ypos);
            myBoard.Peg.XPos.Should().Be(expectedXPosition);
            myBoard.Peg.Direction.Should().Be("W");
        }

        [TestCase("N", "W")]
        [TestCase("W", "S")]
        [TestCase("S", "E")]
        [TestCase("E", "N")]
        public void LeftCommand_Should_Turn_Peg_Accordingly_And_Not_Change_Pos(string initialDir, string expectedDir)
        {
            const int xpos = 3;
            const int ypos = 2;
            myBoard = engine.InitWithGivenPos(BOARD_SIZE, xpos, ypos, initialDir);
            myBoard = engine.PerformCommand(myBoard, 'L');

            myBoard.Peg.YPos.Should().Be(ypos);
            myBoard.Peg.XPos.Should().Be(xpos);
            myBoard.Peg.Direction.Should().Be(expectedDir);
        }

        [TestCase("N", "E")]
        [TestCase("E", "S")]
        [TestCase("S", "W")]
        [TestCase("W", "N")]
        public void RightCommand_Should_Turn_Peg_Accordingly_And_Not_Change_Pos(string initialDir, string expectedDir)
        {
            const int xpos = 3;
            const int ypos = 2;
            myBoard = engine.InitWithGivenPos(BOARD_SIZE, xpos, ypos, initialDir);
            myBoard = engine.PerformCommand(myBoard, 'R');

            myBoard.Peg.YPos.Should().Be(ypos);
            myBoard.Peg.XPos.Should().Be(xpos);
            myBoard.Peg.Direction.Should().Be(expectedDir);
        }

        [TestCase("LMMMM", "0 0 W")]
        [TestCase("MRMLMRM", "2 2 E")]
        [TestCase("RMMMLMM", "3 2 N")]
        [TestCase("MMMMM", "0 4 N")]
        public void After_A_SequenceOfCommands_Should_Return_Board_In_Expected_Format(string moves, string expectedResult)
        {
            var resultBoard = engine.ProcessInputSequence(moves, myBoard);
            resultBoard.ToString().Should().Be(expectedResult);
        }

    }
}
