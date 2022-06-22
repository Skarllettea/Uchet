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
using System.Net;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using SmtpClient = System.Net.Mail.SmtpClient;


namespace Simplay
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Connection connection = new Connection();

        public Registration()
        {
            InitializeComponent();
            FirstName.MaxLength = 20;
            LastName.MaxLength = 20;
            Age.MaxLength = 3;
            LoginBox2.MaxLength = 20;
            PasswordBox2.MaxLength = 20;
            Email.MaxLength = 50;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection();

            var firstName = FirstName.Text;
            var lastName = LastName.Text;
            var age = Convert.ToInt32(Age.Text);
            var loginUser = LoginBox2.Text;
            var passdUser = PasswordBox2.Password;
            var emailUser = Email.Text;

            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 587);
            Smtp.UseDefaultCredentials = false;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Smtp.EnableSsl = true;
            Smtp.Credentials = new NetworkCredential("dakotaroyz333@gmail.com", "kesha55555");
            MailMessage email = new MailMessage();
            email.From = new MailAddress("dakotaroyz333@gmail.com");
            email.Subject = "Регистрация в приложении SimPlay";
            email.Body = "Вы успешно зарегистрированы в нашем интернет-магазине компьютерных игр SimPlay\nВаш логин: " + loginUser + "\nПароль: " + passdUser;
            email.To.Add(emailUser);
            Smtp.Send(email);

            string querystring = $"insert into Users(firstName, lastName, age, login, password, email) values('{firstName}', '{lastName}', '{age}', '{loginUser}', '{passdUser}', '{emailUser}')";
            
            SqlCommand command = new SqlCommand(querystring, connection.getConnection());

            connection.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вы успешно зарегистрировались");
            }
            else
            {
                MessageBox.Show("Не удалось зарегистрироваться /n Пожалуйста, проверьте данные ещё раз");
            }
            connection.closeConnection();
        }

        private bool checkUser()
        {
            var loginUser1 = LoginBox2.Text;
            var passdUser1 = PasswordBox2.Password;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select idUser, login, password from Users where login = '{loginUser1}' and password = '{passdUser1}'";

            SqlCommand command = new SqlCommand(querystring, connection.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Такой пользователь уже существует");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
