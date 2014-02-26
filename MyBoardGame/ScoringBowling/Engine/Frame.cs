namespace ScoringBowling.Engine
{
    public class FrameBase
    {
        public FrameBase(int n)
        {
            this.Number = n;
        }

        public virtual int Number { get; private set; }
        public int Strike { get; set; }
    }
    public class Frame : FrameBase
    {
//        public Frame Next { get; set; }
        public Frame(int n) : base(n)
        {
        }
    }
    public class TenthFrame : FrameBase
    {
        public override int Number
        {
            get { return 10; }
        }

        public TenthFrame() : base(10)
        {
        }
    }
}
