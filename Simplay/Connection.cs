using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Simplay
{
    class Connection
    {
        //Connection connection = new Connection();
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-A5AV8TP;Initial Catalog=simplay;Integrated Security=true");
        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

        /*public void AddGame(string name, int ageLimit, string description, int price)
        {
            string querystring = $"insert into Game(name, ageLimit, description, price);";

            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(querystring, connection.getConnection());
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
        }
        
        public List<Game> ReadGame()
        {
            List<Game> games = new List<Game>();
            string querystring = $"select * from Game;";
            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(querystring, connection.getConnection());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        games.Add(new Game()
                        {
                            idGame = reader.GetInt32(0),
                            name = reader.GetString(1),
                            ageLimit = reader.GetInt32(2),
                            description = reader.GetString(3),
                            price = reader.GetInt32(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlConnection.Close();
            return games;
        }*/
    }
}
