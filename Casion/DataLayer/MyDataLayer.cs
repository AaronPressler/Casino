using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MyDataLayer : IDataLayer
    {
        private string _kindOfDataLayer;
        private IDataLayer _dataLayer;

        public MyDataLayer() {

            _kindOfDataLayer = "MySQL";
                //ConfigurationManager.AppSettings["DataLayer"]
            if (string.IsNullOrEmpty(_kindOfDataLayer))
            {
                _kindOfDataLayer = "MySQL";
            }
            switch (_kindOfDataLayer.ToUpper())
            {                
                case "XML":
                    _dataLayer = new DataLayer.XML.DataLayer();
                    break;
                case "JSON":
                    _dataLayer = new DataLayer.JSON.DataLayer();
                    break;
                case "MYSQL":
                    _dataLayer = new DataLayer.SQL.DataLayer();
                    break;
                default:
                    throw new ArgumentException("undefined data layer configuration");
            }
        }

        public List<Player> LoadPersons()
        {
            return _dataLayer.LoadPersons();
        }

        public void SavePersons(List<Player> persons)
        {
            _dataLayer.SavePersons(persons);
        }
        public void UpdatePoints(Player person)
        {
            _dataLayer.UpdatePoints(person);
        }

        public string GetUTF8(string player) 
        {
            return _dataLayer.GetUTF8(player);
        }

    }
}
