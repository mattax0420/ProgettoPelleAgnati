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
        public string userName { get; set; }


        public login()
        {
            InitializeComponent();
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
