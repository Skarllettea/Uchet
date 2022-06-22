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

namespace Simplay
{
    /// <summary>
    /// Логика взаимодействия для SaleOk.xaml
    /// </summary>
    public partial class SaleOk : Window
    {
        Connection connection = new Connection();
        public SaleOk()
        {
            InitializeComponent();
            GenerateKey();
        }
        public string GenerateKey()//метод генерации ключа
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890123456789";
            var random = new Random();
            var result = new string(Enumerable.Repeat(chars, 16).Select(s => s[random.Next(s.Length)]).ToArray());
            Key.Text = result;

            return result;
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
