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
using Casino.Models;
using LeaderBoardEntry;
public class UserClient : IDataLayer
{
    Casino.Controllers.PlayerController pc = new Casino.Controllers.PlayerController();


    public List<Player> LoadPersons()
    {
        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            try
            {
                string json = client.DownloadString("http://localhost:1234/Player/GetUserData");
                var loginModels = JsonConvert.DeserializeObject<List<LeaderBoardEntry.LoginModel>>(json);

                var players = loginModels.Select(lm => new Player
                {
                    id = lm.id != Guid.Empty ? lm.id : Guid.NewGuid(),
                    UserName = lm.UserName ?? "",
                    Password = lm.Password ?? "",
                    Points = lm.Points,
                    Salt = lm.Salt ?? ""
                }).ToList();

                return players;
            }
            catch (WebException)
            {
                // Fehlerbehandlung, Logging etc.
                return new List<Player>();
            }
            catch (Exception)
            {
                // Fehlerbehandlung für andere Fehler
                return new List<Player>();
            }
        }
    }



    public void SavePersons(List<Player> persons)
    {
        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            foreach (var player in persons)
            {
                try
                {
                    var loginModel = new LeaderBoardEntry.LoginModel
                    {
                        UserName = player.UserName,
                        Password = player.Password,
                        // Standardwerte für nicht gesetzte Felder
                        Age = 0,
                        Points = 0,
                        Salt = player.Salt ?? "",
                        id = player.id != Guid.Empty ? player.id : Guid.NewGuid()
                    };
                    string jsonString = JsonConvert.SerializeObject(loginModel);
                    client.UploadString("http://localhost:1234/Player/Register", "POST", jsonString);
                }
                catch (WebException)
                {
                    // Fehlerbehandlung, Logging etc.
                }
            }
        }
    }

    public bool Login(string username, string password)
    {
        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            try
            {
                var loginModel = new LeaderBoardEntry.LoginModel { UserName = username, Password = password };
                string jsonString = JsonConvert.SerializeObject(loginModel);
                string response = client.UploadString("http://localhost:1234/Player/Login", "POST", jsonString);
                dynamic result = JsonConvert.DeserializeObject(response);
                return result.success == true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }

    public bool Register(string username, string password)
    {
        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            try
            {
                var loginModel = new LeaderBoardEntry.LoginModel
                {
                    UserName = username,
                    Password = password,
                    Age = 20,
                    Points = 0,
                    Salt = "",
                    id = Guid.NewGuid()
                };
                string jsonString = JsonConvert.SerializeObject(loginModel);
                string response = client.UploadString("http://localhost:1234/Player/Register", "POST", jsonString);
                dynamic result = JsonConvert.DeserializeObject(response);
                return result.success == true;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }

    public string GetUTF8(string person)
    {
        throw new NotImplementedException();
    }
}
