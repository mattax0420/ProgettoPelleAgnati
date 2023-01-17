using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pellegrinoAgnati
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private readonly ImageSource[] quadratini = new ImageSource[]  //singola piastra che compone il blocco 
        {                                                                       //numeri che riempiranno l array nella classe grigliaDiGioco
            new BitmapImage(new Uri("Assets/TileEmpty.png",UriKind.Relative)),      // 0 -> vuoto
            new BitmapImage(new Uri("Assets/TileCyan.png",UriKind.Relative)),        //1 -> azzurro
            new BitmapImage(new Uri("Assets/TileBlue.png",UriKind.Relative)),       //2 -> blu
            new BitmapImage(new Uri("Assets/TileOrange.png",UriKind.Relative)),       //3-> arancio
            new BitmapImage(new Uri("Assets/TileYellow.png",UriKind.Relative)),      //4-> giallo
            new BitmapImage(new Uri("Assets/TileGreen.png",UriKind.Relative)),     //5-> verde
            new BitmapImage(new Uri("Assets/TilePurple.png",UriKind.Relative)),     //6-> viola
            new BitmapImage(new Uri("Assets/TileRed.png",UriKind.Relative))      //7-> rosso
        };
        private readonly ImageSource[] blocchi = new ImageSource[]      //vari blocchi 
        {
            new BitmapImage(new Uri("Assets/Block-Empty.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-I.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-J.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-L.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-O.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-S.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-T.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/Block-Z.png",UriKind.Relative))
        };

        private readonly Image[,] imageControls;

        private gameState gameState = new gameState();

        private DispatcherTimer timer;
        private TimeSpan fallIntervall;

        public MainWindow()
        {
            InitializeComponent();
            imageControls = SetupGameCanvas(gameState.grid);

            //timer
            fallIntervall = TimeSpan.FromMilliseconds(700);
            timer = new DispatcherTimer();
            timer.Tick += OnTimedEvent;
            timer.Interval = fallIntervall;
            timer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            if (!gameState.GameOVer)
            {
                gameState.moveGiu();
                Draw(gameState);
            }
            else    //mostro finestra gameover
            {
                gameOverMenu.Visibility = Visibility.Visible;
            }
        }

        private Image[,] SetupGameCanvas(grigliaDiGioco grid)
        {
            Image[,] imageControls = new Image[grid.NRighe, grid.NColonne];
            int cellSize = 25;

            for (int r = 0; r < grid.NRighe; r++)
            {
                for (int c = 0; c < grid.NColonne; c++)
                {
                    Image imageControl = new Image
                    {
                        Width = cellSize,
                        Height = cellSize
                    };

                    Canvas.SetTop(imageControl, (r - 2) * cellSize + 10);
                    Canvas.SetLeft(imageControl, c * cellSize);
                    grigliaGioco.Children.Add(imageControl);
                    imageControls[r, c] = imageControl;
                }
            }

            return imageControls;
        }

        private void DrawGrid(grigliaDiGioco grid)
        {
            for (int r = 0; r < grid.NRighe; r++)
            {
                for (int c = 0; c < grid.NColonne; c++)
                {
                    int id = grid[r, c];
                    imageControls[r, c].Opacity = 1;
                    imageControls[r, c].Source = quadratini[id];
                }
            }
        }

        private void DrawBlock(Blocco block)
        {
            foreach (Pos p in block.BlocchettoPos())
            {
                imageControls[p.Riga, p.Colonna].Opacity = 1;
                imageControls[p.Riga, p.Colonna].Source = quadratini[block.IDBlocco];
            }
        }



        private void Draw(gameState gameState)
        {
            DrawGrid(gameState.grid);
            DrawBlock(gameState.BloccoCorrente);

        }



        private void window_keyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOVer)
            {
                return;
            }
            switch (e.Key)
            {
                case Key.S:
                    gameState.moveGiu();
                    break;
                case Key.A:
                    gameState.moveSinistra();
                    break;
                case Key.D:
                    gameState.moveDestra();
                    break;
                case Key.Left:
                    gameState.rotateOrario();
                    break;
                case Key.Right:
                    gameState.rotateAntiOrario();
                    break;
                default: return;
            }

            Draw(gameState);
        }













        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
