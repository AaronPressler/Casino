using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLayer.XML
{
    public class DataLayer : IDataLayer
    {
        private string _filename;

        public DataLayer()
        {
            _filename = ConfigurationManager.AppSettings["XMLDataPath"];
        }

        private void SaveData(List<Player> persons)
        {
            Data data = new Data();
            data.Players     = persons;

            XmlSerializer serializer = new XmlSerializer(typeof(Data));
            using (Stream stream = new FileStream(_filename, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                serializer.Serialize(stream, data);
            }
        }

        private List<Player> LoadData()
        {
            Data data = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Data));
            using (Stream stream = new FileStream(_filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                data = serializer.Deserialize(stream) as Data;
            }

            if (data != null)
            {
                return data.Players;
            }

            return null;
        }

        public List<Player> LoadPersons()
        {
            return LoadData();
        }

        public void SavePersons(List<Player> persons)
        {
            SaveData(persons);
        }
        public string GetUTF8(string player)
        {
            return Encoding.UTF8.GetBytes(player).ToString();
        }
    }
}
