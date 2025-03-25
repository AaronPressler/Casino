
using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace DataLayer.JSON
{
    public class DataLayer : IDataLayer
    {
        private string _filename;
        private JsonSerializerSettings _serializerSettings;

        public DataLayer()
        {
            _filename = ConfigurationManager.AppSettings["JSONDataPath"];
            _serializerSettings = new JsonSerializerSettings()
            {
                //hallo aaron
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            };
        }

        private void SaveData(List<Player> persons)
        {
            Data data = new Data();
            data.Persons = persons;

            string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented, _serializerSettings);
            using (Stream s = new FileStream(_filename, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
                s.Write(bytes, 0, bytes.Length);
            }
        }
        private List<Player> LoadData()
        {
            _filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "data.json");
            if (!File.Exists(_filename))
            {
                return new List<Player>();
            }

            Data data = null; 
            string jsonString = null;
         

            using (Stream s = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                byte[] bytes = new byte[s.Length];
                s.Read(bytes, 0, bytes.Length);
                jsonString = Encoding.UTF8.GetString(bytes);

            }
            data = JsonConvert.DeserializeObject(jsonString, _serializerSettings) as Data;

            if (data != null)
            {
                return data.Persons;
            }

            return null;
        }

        public List<Player> LoadPersons()
        {
            return LoadData();
        }

        public string GetUTF8(string player)
        {
            byte[] pw =  Encoding.UTF8.GetBytes(player);
           
            return pw.ToString(); 
        }

        public void SavePersons(List<Player> players)
        {
            SaveData(players);
        }
    }
}
