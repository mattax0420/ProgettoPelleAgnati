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

namespace Tetris
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ImageSource[] ImmaginiPiastre = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/TileEmpty.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileCyan.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileBlue.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileOrange.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileYellow.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileGreen.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TilePurple.png",UriKind.Relative)),
            new BitmapImage(new Uri("Assets/TileRed.png",UriKind.Relative))
        };

        private readonly ImageSource[] ImmaginiBlocchi = new ImageSource[]
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

        private readonly Image[,] ControlImmagine;
        private StatoGioco gameState = new StatoGioco();

        public MainWindow()
        {
            InitializeComponent();
            ControlImmagine = SetupCanvas(gameState.grigliaGioco);
        }
        private Image[,] SetupCanvas(Griglia grid)
        {
            Image[,] ControlImmagine = new Image[grid.Riga, grid.Colonna];
            int grandezzaCella = 25;

            for(int r = 0; r < grid.Riga; r++)
            {
                for(int c = 0; c < grid.Colonna; c++)
                {
                    Image ControlloImmagine = new Image
                    {
                        Width = grandezzaCella,
                        Height = grandezzaCella
                    };

                    Canvas.SetTop(ControlloImmagine, (r - 2) * grandezzaCella);
                    Canvas.SetLeft(ControlloImmagine, c * grandezzaCella);
                    GameCanvas.Children.Add(ControlloImmagine);
                    ControlImmagine[r, c] = ControlloImmagine;
                }
            }
            return ControlImmagine;
        }

        private void DisegnaGriglia(Griglia grid)
        {
            for(int r = 0; r < grid.Riga; r++)
            {
                for(int c = 0; c < grid.Colonna; c++)
                {
                    int id = grid[r, c];
                    ControlImmagine[r, c].Source = ImmaginiPiastre[id];
                }
            }
        }

        private void DisegnaBlocco(Blocco block)
        {
            foreach(Posizione p in block.PosizionePiastra())
            {
                ControlImmagine[p.Riga, p.Colonna].Source = ImmaginiPiastre[block.ID];
            }
        }

        private void Disegna(StatoGioco stato)
        {
            DisegnaGriglia(stato.grigliaGioco);
            DisegnaBlocco(stato.BloccoAttuale);
        }

        private async Task Loop()
        {
            Disegna(gameState);
            while (!gameState.Sconfitta)
            {
                await Task.Delay(500);
                gameState.InBasso();
                Disegna(gameState);
            }
        }
        private void Window_KeyDown(object sender,KeyEventArgs e)
        {
            if (gameState.Sconfitta)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    gameState.Sinistra();
                    break;
                case Key.Right:
                    gameState.Destra();
                    break;
                case Key.Down:
                    gameState.InBasso();
                    break;
                case Key.Up:
                    gameState.RuotaBlocco1();
                    break;
                case Key.Z:
                    gameState.RuotaBlocco2();
                    break;
                default:
                    return;
            }
            Disegna(gameState);
        }

        private async void GameCanvas_Loaded(object sender,RoutedEventArgs e)
        {
            await Loop();
        }

        private void GiocaAncora_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
