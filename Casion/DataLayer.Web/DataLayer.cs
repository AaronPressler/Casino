using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataLayer.Web;
using Domain;
using Newtonsoft.Json;
public class UserClient : IDataLayer
{
    Casino.Controllers.PlayerController pc = new Casino.Controllers.PlayerController();
   

    public List<Player> LoadPersons()
    {
        Player player = new Player()
        {
            UserName = "Aaron",
            Password = "123"
        };
        List<Player> players = new List<Player>() { player };
        
        Data data = new Data(players);
        using (WebClient client = new WebClient())
        {
            try
            {
                data = JsonConvert.DeserializeObject(client.DownloadString($"http://localhost:5000/application/json/")) as Data;
            }
            catch (WebException ex)
            {
            }
        }
        return data.Persons;
    }

    public void SavePersons(List<Player> persons)
    {
        string jsonString = JsonConvert.SerializeObject(persons, Formatting.Indented);

        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            try
            {
                client.UploadString("http://localhost:5000/application/json/", "POST", jsonString);
            }
            catch (WebException ex)
            {

            }
        }
    }

    public string GetUTF8(string person)
    {
        throw new NotImplementedException();
    }
}
