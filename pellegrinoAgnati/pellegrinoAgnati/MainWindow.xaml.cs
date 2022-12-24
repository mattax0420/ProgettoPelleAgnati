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
        private readonly ImageSource[] quadratini = new ImageSource[]  //singola piastra che compone il blocco complessivo
        {
            new BitmapImage(new Uri("Assets/TileRed.png",UriKind.Relative))
        };

        private readonly ImageSource[] blocchi = new ImageSource[]
        {
            new BitmapImage(new Uri("Assets/Block-Z.png",UriKind.Relative))
        };
        public MainWindow()
        {
            InitializeComponent();
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

 
    }
}
