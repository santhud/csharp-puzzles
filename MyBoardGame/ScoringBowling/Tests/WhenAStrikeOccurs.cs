using FluentAssertions;
using NUnit.Framework;
using ScoringBowling.Engine;

namespace ScoringBowling.Tests
{
    [TestFixture]
    public class WhenAStrikeOccurs
    {
        private Game game;

        [SetUp]
        public void Init()
        {
            game = new Game();
        }

        [Ignore]
        [Test]
        public void Then_Points_From_TwoSubsequent_Hits_Should_Be_Awarded_As_Bonus()
        {
            game.Strike(10);
            game.Strike(4);
            game.Strike(6);
            game.Strike(3);

            game.TotalPoints.Should().Be(33);
        }
    }
}

