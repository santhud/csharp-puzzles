using FluentAssertions;
using NUnit.Framework;
using ScoringBowling.Engine;

namespace ScoringBowling.Tests
{
    [TestFixture]
    public class AnyPointScoredInFirstFrameShould
    {
        private Game game;

        [SetUp]
        public void Init()
        {
            game = new Game();
        }

        [Test]
        public void Result_In_Score_Being_Unchanged_When_I_Strike_0_Pins()
        {
            var existingScore = game.TotalPoints;

            game.Strike(0);

            var result = game.TotalPoints;

            result.Should().Be(existingScore);
        }

        [Test]
        public void Result_In_Score_Being_Updated_To_0_Plus_CurrentStrikePoints()
        {
            var prevPoints = game.TotalPoints;
            var currentStrike = 4;

            game.Strike(currentStrike);

            game.TotalPoints.Should().Be(prevPoints + currentStrike);
        }

        [Test]
        public void Result_In_Score_Being_Updated_To_ExistingScore_Plus_CurrentStrikePoints()
        {
            var previousStrike = 3;
            var currentStrike = 4;

            game.Strike(previousStrike);
            var prevPoints = game.TotalPoints;
            game.Strike(currentStrike);

            game.TotalPoints.Should().Be(prevPoints + currentStrike);
        }
    }
}
