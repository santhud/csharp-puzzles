using System.Threading;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using Game.Console;

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void AddRectangles()
        {
            canvas1.Children.Clear();
            var gameEngine = new GameEngine();
            Thread.Sleep(200);
            int ii = gameEngine.GetIndexOfInput().Item1, jj = gameEngine.GetIndexOfInput().Item2;

            for (var i = 0; i < ii; i++)
            {
                for (var j = 0; j < jj; j++)
                {
                    if (gameEngine.CurrentState1[i, j])
                    {
                        canvas1.Children.Add(new Rectangle {Height = 10, Width = 10, Fill = Brushes.Blue});
                    }
                    else
                    {
                        canvas1.Children.Add(new Rectangle {Height = 10, Width = 10, Fill = Brushes.White});
                    }
//                    System.Console.Write( ? "O" : ".");
                }
                System.Console.WriteLine();
            }


        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            AddRectangles();
        }
    }
}
