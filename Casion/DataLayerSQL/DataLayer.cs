using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Google.Protobuf.Compiler;
using System.Data;

namespace DataLayer.SQL
{

    public class DataLayer : IDataLayer
    {
        private MySqlConnection _connection;
        public DataLayer()
        {
            _connection = new MySqlConnection("Server=62.178.173.135;Port=3306;Database=sew3_web_games;User ID=sew_db;Password=SewPassword123!;SslMode=none;;AllowPublicKeyRetrieval=True;");
        }

        public List<Player> LoadPersons()
        {
            List<Player> dbList = new List<Player>();
            string query = "SELECT id, Username, Points, password_hash, salt FROM user";
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dbList.Add(new Player
                {
                    UserName = reader["Username"].ToString(),
                    Points = Convert.ToInt32(reader["Points"]),
                    Password = reader["password_hash"].ToString(),
                    Salt = reader["salt"].ToString(),
                    id = Guid.Parse(reader["id"].ToString()),
                });
            }

            _connection.Close();
            return dbList;
        }

        public void SavePersons(List<Player> players)
        {
            foreach (Player p in players)
            {
                if (p.id.ToString()[0] == '0')
                {
                    p.CreatANewId();
                }
                SaveData(p);
            }

        }
        public void SaveData(Player person)
        {
            _connection.Close();
            string query = @"
                    INSERT INTO user ( Username, Points, password_hash, salt, id)
                    VALUES ( @UserName, @Points, @password_hash, @salt, @id)
                    ON DUPLICATE KEY UPDATE 
                        Username = @Username,
                        Points = @Points,
                        password_hash = @password_hash,
                        salt = @salt;
                       
                ";
            _connection.Open();

            using (var command = new MySqlCommand(query, _connection))
            {
                // Parameter zuweisen
                command.Parameters.AddWithValue("@UserName", person.UserName);
                command.Parameters.AddWithValue("@Points", person.Points);
                command.Parameters.AddWithValue("@password_hash", person.Password);
                command.Parameters.AddWithValue("@salt", person.Salt);
                command.Parameters.AddWithValue("@id", person.id.ToString());

                // Query ausführen
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
        public void UpdatePoints(Player person)
        {
            try
            {
                // Verbindung schließen, falls sie noch offen ist
                if (_connection.State != System.Data.ConnectionState.Closed)
                    _connection.Close();

                string query = @"
            UPDATE user
            SET Points = @Points
            WHERE id = @id;
        ";

                _connection.Open();

                using (var command = new MySqlCommand(query, _connection))
                {
                    // Nur die Punkte und die ID als Parameter zuweisen
                    command.Parameters.AddWithValue("@Points", person.Points);
                    command.Parameters.AddWithValue("@id", person.id.ToString());

                    // Query ausführen
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung: z.B. Log-Ausgabe
                Console.WriteLine("Fehler beim Aktualisieren der Punkte: " + ex.Message);
            }
            finally
            {
                // Verbindung immer wieder schließen
                if (_connection.State != System.Data.ConnectionState.Closed)
                    _connection.Close();
            }
        }


        public string GetUTF8(string player)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(player);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }


}
