using FluentAssertions;
using NUnit.Framework;
using ScoringBowling.Engine;

namespace ScoringBowling.Tests
{
    [TestFixture]
    public class AnyPointScoredInMultipleFramesShould
    {
        private Game game;

        [SetUp]
        public void Init()
        {
            game = new Game();
        }

        [Test]
        public void Result_In_Score_Remaining_0_When_I_Hit_0_Points()
        {
            int i = 20;
            while (i > 0)
            {
                game.Strike(0);
                i--;
            }
            game.TotalPoints.Should().Be(0);
        }

        [Test]
        public void Result_In_Score_Being_20_When_I_Hit_1_Point_In_Each()
        {
            int i = 20;
            while (i > 0)
            {
                game.Strike(1);
                i--;
            }
            game.TotalPoints.Should().Be(20);
        }

    }
}
