using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Domain;
public class UserClient
{
    
    public void UploadUser(string user)
    {
        
        string json = JsonSerializer.Serialize(user);

        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            try
            {
                client.UploadString("http://localhost:5000/", "POST", json);
            }
            catch (WebException ex)
            {
               
            }
        }
    }

    public void DownloadUser(int userId)
    {
        using (WebClient client = new WebClient())
        {
            try
            {
                string json = client.DownloadString($"http://localhost:5000/");
                Player user = JsonSerializer.Deserialize<Player>(json);
            }
            catch (WebException ex)
            {
            }
        }
    }


}
