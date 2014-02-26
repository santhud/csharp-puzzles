using System;

namespace ScoringBowling.Engine
{
    public class Game
    {
        public int TotalPoints { get; private set; }
        private int hitCount;
        public Frame CurrentFrame { get; private set; }

        public Game()
        {
            this.CurrentFrame = new Frame(1);
        }

        public void Strike(int strikePoints)
        {
            this.TotalPoints += strikePoints;
            hitCount++;
            if ((hitCount%2) == 0)
            {
                if (this.CurrentFrame.GetType() == typeof(TenthFrame))
                {
                    this.CurrentFrame = new Frame(0);
                }
                else
                {
                    this.CurrentFrame = new Frame(this.CurrentFrame.Number+1);
                }
            }
        }
    }
}
