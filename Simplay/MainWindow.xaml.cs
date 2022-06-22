using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Simplay
{
    public partial class MainWindow : Window
    {
        int selectedRow;
        public MainWindow()
        {
            InitializeComponent();
            GameGrid.ItemsSource = simplayEntities3.GetContext().Game.ToList();
        }


        /*private void Games_ListChanged(object sender, ListChangedEventArgs e)
        {
            throw new NotImplementedException();
        }*/

        private void Autorization(object sender, MouseButtonEventArgs e)
        {
            Autorization autorization = new Autorization();
            autorization.Show();
            this.Close();
        }

        private void Registration(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            AddGame addGame = new AddGame(null);
            addGame.Show();
            this.Close();
        }

        private void btnChng(object sender, RoutedEventArgs e)
        {
            ChangeGame changeGame = new ChangeGame(GameGrid.SelectedItem as Game);
            changeGame.Show();
            this.Close();
        }

        private void btnDel(object sender, RoutedEventArgs e)
        {
            var gameForRemoving = GameGrid.SelectedItems.Cast<Game>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {gameForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    simplayEntities3.GetContext().Game.RemoveRange(gameForRemoving);
                    simplayEntities3.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    GameGrid.ItemsSource = simplayEntities3.GetContext().Game.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void saleGame(object sender, RoutedEventArgs e)
        {
            SaleGame saleGame = new SaleGame();
            saleGame.Show();
            this.Close();
        }
    }
}
