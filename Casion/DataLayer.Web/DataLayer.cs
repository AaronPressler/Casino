using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Web
{
    internal class DataLayer
    {

    }
    public class WebDataService
    {
        private readonly SqlDataLayer _sqlDataLayer;

        public WebDataService()
        {
            _sqlDataLayer = new SqlDataLayer();
        }

        public void SaveData(YourDataModel model)
        {
            // Hier könnte man z.B. Validierungen einbauen
            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentException("Name darf nicht leer sein.");

            _sqlDataLayer.InsertData(model);
        }
    }

}
