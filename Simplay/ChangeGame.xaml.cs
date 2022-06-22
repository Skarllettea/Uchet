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
    /// Логика взаимодействия для ChangeGame.xaml
    /// </summary>
    public partial class ChangeGame : Window
    {
        private Game _currentGame = new Game();

        public ChangeGame(Game selectedGame)
        {
            InitializeComponent();

            if (selectedGame != null)
                _currentGame = selectedGame;

            DataContext = _currentGame;
        }

        private void cancelGame(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Отменить изменения?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void btnSaveGame(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentGame.name))
                errors.AppendLine("Поле названия игры не должно быть пустым");

            if (string.IsNullOrWhiteSpace(_currentGame.description))
                errors.AppendLine("Поле описания игры не должно быть пустым");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                //return;
            }


            if (_currentGame.idGame == 0)
            {
                MessageBoxResult result = MessageBox.Show("Сохранить изменения?", "Сообщение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    simplayEntities3.GetContext().Game.Remove(_currentGame);
                    simplayEntities3.GetContext().Game.Add(_currentGame);
                    try
                    {
                        simplayEntities3.GetContext().SaveChanges();
                        MessageBox.Show("Игра добавлена");
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }
}
