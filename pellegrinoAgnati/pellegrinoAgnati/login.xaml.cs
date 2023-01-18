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
using System.Windows.Shapes;

namespace pellegrinoAgnati
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public enum difficolta
        {
            facile, difficile
        }
        public difficolta difficult { get; set; }
        public string userName { get; set; }


        public login()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUser.Text != "")
            {
                ConnectionWithServer connessione = new ConnectionWithServer();
                try
                {
                    userName = txtUser.Text;
                    connessione.Connection(txtUser.Text);
                    DialogResult = true;
                    if (rdDifficile.IsChecked == true)
                        difficult = difficolta.difficile;
                    else if (rdFacile.IsChecked == true)
                        difficult = difficolta.facile;
                    this.Close();

                }
                catch { }

            }
            else
            {
                MessageBox.Show("INSERIRE UN NOME!!!");
            }
        }
    }
}
