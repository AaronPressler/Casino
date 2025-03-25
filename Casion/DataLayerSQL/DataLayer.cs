using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Google.Protobuf.Compiler;
using System.Data;

namespace DataLayerSQL
{

    internal class DataLayer : IDataLayer
    {
        private MySqlConnection _connection;
        public DataLayer()
        {
            _connection = new MySqlConnection("Server=localhost;Port=3306;Database=sew3_web_games;User ID=root;Password=;SslMode=none;");
        }

        public List<Player> LoadPersons()
        {
            List<Player> dbList = new List<Player>();
            string query = "SELECT id, user_name, tokens, score, password_hash, role, salt, guid, birthdate FROM user";
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dbList.Add(new Player
                {
                    UserName = reader["Username"] as string,
                    Points = Convert.ToInt32(reader["Points"] as string),
                    Password = reader["password_hash"] as string,
                    Salt = reader["salt"] as string,
                    id = Guid.Parse(reader["id"] as string),
                });
            }
            _connection.Close();
            return dbList;
        }

        public void SavePersons(List<Player> players)
        {
            foreach (Player p in players)
                SaveData(p);
        }
        public void SaveData(Player person)
        {
            _connection.Close();
            string query = @"
                    INSERT INTO user ( Username, Points, Password, Salt, id)
                    VALUES ( @UserName, @Points, @Password, @Salt, @id)
                    ON DUPLICATE KEY UPDATE 
                        Username = VALUES(Username),
                        Points = VALUES(Points),
                        Password = VALUES(Password),
                        Salt = VALUES(Salt),
                        id = VALUES(id),
                ";
            _connection.Open();

            using (var command = new MySqlCommand(query, _connection))
            {
                // Parameter zuweisen
                command.Parameters.AddWithValue("@UserName", person.UserName);
                command.Parameters.AddWithValue("@Points", person.Points);
                command.Parameters.AddWithValue("@Password", person.Password);
                command.Parameters.AddWithValue("@Salt", person.Salt);
                command.Parameters.AddWithValue("@id", person.id.ToString());

                // Query ausführen
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public string GetUTF8(string player)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(player);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }


}
