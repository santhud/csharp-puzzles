using System;
using System.Collections.Generic;

namespace ToH
{
    static class ToHProgram
    {
        static readonly Tower Tower1 = new Tower("tower1");
        static readonly Tower Tower2 = new Tower("tower2");
        static readonly Tower Tower3 = new Tower("tower3");
        private const int TOTAL_DISCS = 4;
        private static int step = 1;

        static void Main(string[] args)
        {
            AddDisks(Tower1, TOTAL_DISCS);

            if(TOTAL_DISCS % 2 == 0)
            {
                MoveEvenNumberOfDisks();
            }
            else
            {
                MoveOddNumberOfDisks();
            }

        }

        private static void MoveEvenNumberOfDisks()
        {
            while (Tower3.Discs.Count < TOTAL_DISCS)
            {
                MoveBetween(Tower1, Tower2);
                if (Tower3.Discs.Count < TOTAL_DISCS)
                    MoveBetween(Tower1, Tower3);
                if (Tower3.Discs.Count < TOTAL_DISCS)
                    MoveBetween(Tower2, Tower3);
            }
        }

        private static void MoveOddNumberOfDisks()
        {
            while (Tower3.Discs.Count < TOTAL_DISCS)
            {
                MoveBetween(Tower1, Tower3);
                if (Tower3.Discs.Count < TOTAL_DISCS)
                    MoveBetween(Tower1, Tower2);
                if (Tower3.Discs.Count < TOTAL_DISCS)
                    MoveBetween(Tower2, Tower3);
            }
        }

        private static void MoveBetween(Tower a, Tower b)
        {
            var towerAHead = a.GetPeekWeight();
            var towerBHead = b.GetPeekWeight();
            if (towerBHead == 0 && towerAHead != 0)
            {
                Move(a, b);
            }
            else if (towerAHead == 0 && towerBHead != 0)
            {
                Move(b, a);
            }
            else if (towerAHead < towerBHead)
            {
                Move(a, b);
            }
            else
            {
                Move(b, a);
            }
        }

        private static void AddDisks(Tower tower, int n)
        {
            for(var i=n; i>0; i--)
            {
                tower.Discs.Push(new Disc(i));
            }
        }

        private static void Move(Tower from, Tower to)
        {
            var disc = from.Discs.Peek();
            if (to.CanAdd(disc))
            {
                to.TryAddOne(disc);
                from.RemoveOne();
                Console.WriteLine("Step {0} ::\tfrom: {1}\tto: {2}", step++, from, to);
            }
        }
    }

    internal class Disc
    {
        protected Disc()
        {
            this.Weight = 0;
        }
        public Disc(int size)
        {
            this.Weight = size;
        }
        public int Weight { get; protected set; }
    }
    internal class NullDisc : Disc
    {
        public NullDisc()
        {
            this.Weight = 0;
        }
    }
    internal class Tower
    {
        public string Name { get; private set; }
        public Stack<Disc> Discs { get; private set; }

        public Tower() : this("", new Stack<Disc>())
        {
        }
        public Tower(string name) : this(name, new Stack<Disc>())
        {
        }
        public Tower(string name, Stack<Disc> discs)
        {
            this.Discs = discs;
            this.Name = name;
        }
        public bool CanAdd(Disc d)
        {
            if(this.Discs.Count > 0)
            {
                return this.Discs.Peek().Weight > d.Weight;
            }
            return true;
        }
        public bool TryAddOne(Disc d)
        {
            if (CanAdd(d))
            {
                this.Discs.Push(d);
                return true;
            }
            return false;
        }
        public Disc RemoveOne()
        {
            return (this.Discs.Peek().Weight > 0) ? this.Discs.Pop() : new NullDisc();
        }
        public int GetPeekWeight()
        {
            if (Discs.Count > 0)
            {
                return Discs.Peek().Weight;
            }
            return 0;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}

