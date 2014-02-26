namespace MyBoardGame.Core
{
    public struct Peg
    {
        private readonly int xPos;
        private readonly int yPos;
        private readonly string direction;

        public Peg(int x, int y, string dir)
        {
            this.xPos = x;
            this.yPos = y;
            this.direction = dir;
        }

        public int XPos
        {
            get { return xPos; }
        }

        public int YPos
        {
            get { return yPos; }
        }

        public string Direction
        {
            get { return direction; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", XPos, YPos, Direction);
        }

    }
}

