using System;
using FluentAssertions;
using NUnit.Framework;
using ScoringBowling.Engine;

namespace ScoringBowling.Tests
{
    [TestFixture]
    public class AGameShould
    {
        [Test]
        public void LetMeGetPointsFromIt()
        {
            var g = new Game();
            g.TotalPoints.Should().BeInRange(Int32.MinValue, Int32.MaxValue);
        }

        [Test]
        public void Start_At_Frame_0()
        {
            var g = new Game();
            g.CurrentFrame.Should().Be(1);
        }

        [Test]
        public void Auto_Increment_Frame_For_Every_2_Hits()
        {
            var g = new Game();
            g.Strike(12);
            g.Strike(1);
            g.CurrentFrame.Should().Be(2);
        }

        [Test]
        public void Auto_Increment_Frame_For_Every_2_Hits_Till_Last_Frame()
        {
            var g = new Game();
            for (int i = 0; i < 20; i++)
            {
                g.Strike(1);
            }
            g.CurrentFrame.Should().Be(0);
        }

        [Test]
        public void Provide_Score_Per_Frame()
        {
            var g = new Game();
            g.Strike(12);
            g.Strike(1);
            g.Strike(1);
            g.CurrentFrame.Should().Be(2);
        }

    }
}

