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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        Connection connection = new Connection();
        public Autorization()
        {
            InitializeComponent();
            LoginBox.MaxLength = 20;
            PasswordBox.MaxLength = 20;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var loginUser = LoginBox.Text;
            var passdUser = PasswordBox.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select idUser, login, password from Users where login = '{loginUser}' and password = '{passdUser}'";

            SqlCommand command = new SqlCommand(querystring, connection.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!");

            }
            else
                MessageBox.Show("Неправильно введённые данные");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
