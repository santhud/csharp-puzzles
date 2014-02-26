using FluentAssertions;
using NUnit.Framework;

namespace MyBoardGame.Core.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void ToStringShouldReturnPegStatus()
        {
            var engine = new Engine();
            var myBoard = engine.InitWithGivenPos(5, 3, 2, "E");
            myBoard.ToString().Should().Be("3 2 E");
        }
    }
}

