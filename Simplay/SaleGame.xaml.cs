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
using System.Data.SqlClient;
using System.Data;

namespace Simplay
{
    /// <summary>
    /// Логика взаимодействия для SaleGame.xaml
    /// </summary>
    public partial class SaleGame : Window
    {
        Connection connection = new Connection();
        public SaleGame()
        {
            InitializeComponent();
            Bank.MaxLength = 50;
            CardNumber.MaxLength = 16;
            Term.MaxLength = 5;
            Cvv.MaxLength = 3;
            Owner.MaxLength = 70;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var bank = Bank.Text;
            var cardNumber = Convert.ToInt32(CardNumber.Text);
            var term = Term.Text;
            var cvv = Convert.ToInt32(Cvv.Text);
            var owner = Owner.Text;

            string querystring = $"insert into Users(bank, cardNumber, term, cvv, owner) values('{bank}', '{cardNumber}', '{term}', '{cvv}', '{owner}')";

            SqlCommand command = new SqlCommand(querystring, connection.getConnection());

            SaleOk saleOk = new SaleOk();
            saleOk.Show();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
