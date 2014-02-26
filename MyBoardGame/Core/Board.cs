namespace MyBoardGame.Core
{
    public struct Board
    {
        private readonly int size;
        private Peg peg;

        public int Size
        {
            get { return size; }
        }

        public Peg Peg
        {
            get { return peg; }
        }

        public Board(int size, int x, int y, string dir)
        {
            this.size = size;
            this.peg = new Peg(x, y, dir);
        }

        public override string ToString()
        {
            return this.Peg.ToString();
        }
    }
}