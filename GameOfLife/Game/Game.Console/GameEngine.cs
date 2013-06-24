using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Linq;

namespace Game.Console
{
    public class GameEngine
    {
        public string InputFile
        {
            get { return ".\\Game.input"; }
        }
        public IEnumerable<IEnumerable<bool>> CurrentState { get; private set; }
        public bool[,] CurrentState1 { get; private set; }

        public GameEngine()
        {
            this.CurrentState = GetInitialStatusOfCells();
            GetInitialStatusOfCells1();
            PrintCurrentGeneration();

            var lifeTimer = new Timer(200);
            lifeTimer.Elapsed += ManipulateLifeOfCells;
            lifeTimer.Start();
        }

        private IEnumerable<IEnumerable<bool>> GetInitialStatusOfCells()
        {
            return File.ReadLines(this.InputFile).Select(line => line.Select(c => c.Equals('O')));
        }

        private void GetInitialStatusOfCells1()
        {
            var indexes = GetIndexOfInput();
            this.CurrentState1 = new bool[indexes.Item1, indexes.Item2];
            int i = 0, j = 0;
            foreach(var line in File.ReadLines(this.InputFile))
            {
                j = 0;
                foreach (var c in line)
                {
                    this.CurrentState1[i, j] = c.Equals('O');
                    j++;
                }
                i++;
            }
        }

        public Tuple<int, int> GetIndexOfInput()
        {
            return new Tuple<int, int>(this.CurrentState.Count(), this.CurrentState.Select(x => x.Count()).First());
        }

        private void ManipulateLifeOfCells(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            int ii = GetIndexOfInput().Item1, jj = GetIndexOfInput().Item2;
            var tmpStatus = new bool[ii, jj];

            for(int i=0; i < ii; i++)
            {
                for(int j=0; j < jj; j++)
                {
                    tmpStatus[i,j] = GetNewStatusBasedOnNeighbours(i, j);
                }
            }
            this.CurrentState1 = tmpStatus;
          //  PrintCurrentGeneration();
        }

        private bool GetNewStatusBasedOnNeighbours(int i, int j)
        {
            var i0 = this.CurrentState1[i, j];
            bool i1 = false, i2 = false, i3 = false, i4 = false, i5 = false, i6 = false, i7 = false, i8 = false;

            try { i1 = this.CurrentState1[i - 1, j - 1]; }
            catch { }
            try { i2 = this.CurrentState1[i - 1, j]; }
            catch { }
            try { i3 = this.CurrentState1[i - 1, j + 1]; }
            catch { }
            try { i4 = this.CurrentState1[i, j - 1]; }
            catch { }
            try { i5 = this.CurrentState1[i, j + 1]; }
            catch { }
            try { i6 = this.CurrentState1[i + 1, j - 1]; }
            catch { }
            try { i7 = this.CurrentState1[i + 1, j]; }
            catch { }
            try { i8 = this.CurrentState1[i + 1, j + 1]; }
            catch { }
            
            var ii = new List<bool> {i1, i2, i3, i4, i5, i6, i7, i8};
            
            if ((i0))
            {
                return (ii.Count(x => x) == 3) || (ii.Count(x => x) == 2);
            }
            return (ii.Count(x => x) == 3);
        }

        public void PrintCurrentGeneration()
        {
            int ii = GetIndexOfInput().Item1, jj = GetIndexOfInput().Item2;

            for (var i = 0; i < ii; i++)
            {
                for (var j = 0; j < jj; j++)
                {
                    System.Console.Write(CurrentState1[i, j] ? "O" : ".");
                }
                System.Console.WriteLine();
            }
//            System.Console.Clear();
            System.Console.WriteLine();

            
        }
    }
}


