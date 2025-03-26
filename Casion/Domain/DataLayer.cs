using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IDataLayer
    {
        List<Player> LoadPersons();

        void SavePersons(List<Player> persons);

        void UpdatePoints(Player person);

        string GetUTF8(string person);   

    }


}
