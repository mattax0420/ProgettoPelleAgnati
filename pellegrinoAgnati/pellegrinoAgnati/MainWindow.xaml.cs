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

                                    //singole celle della grid, una immagine in ogni cella 
        private Image[,] celle;     //20 righe 10 colonne come griglia di gioco


        public MainWindow()
        {
            InitializeComponent();
        }

        private Image[,] SetUpCanvas(grigliaDiGioco grid)
        {
            Image[,] celle = new Image[grid.NRighe, grid.NColonne];
            int cellSize = 25;  //in base a width e heigth del canvas

            /*looppo la tabella e disegno le celle */
            for (int r = 0; r < grid.NRighe; r++)
            {
                for (int c = 0; c < grid.NColonne; c++)
                {                                                                                     //NO Image cella = new Image(cellSize,cellSize);
                    Image cella = new Image
                    {       //setto le prop
                        Width = cellSize,
                        Height = cellSize,
                    };
                    Canvas.SetTop(cella, cellSize);
                    Canvas.SetLeft(cella, cellSize);
                    //celle = this.celle
                }
            }
            return this.celle;
        }

        private void GameCanvas_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void window_keyDown(object sender, KeyEventArgs e)
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
