using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Casino.Models;
using Newtonsoft.Json;
using Cards;
using System.Diagnostics;
using Game.Logik;
using System.Web.SessionState;
using MySql.Data.MySqlClient;
using System.Web;
using System.Net;
using Domain;
using System.Web.Http;
using Org.BouncyCastle.Crypto.Parameters;

namespace Casino.Controllers
{

    public class PlayerController : Controller
    {
      
        
        public PlayerController()
        {
           
        }

        public List<LoginModel> GetList()
        {
            Logic g = new Logic();
            List<LoginModel> list = new List<LoginModel>();
            List<LeaderBoardEntry.LoginModel> list2 = g.GetUsers();
            foreach (var item in list2)
            {
                list.Add((LoginModel)item);
            }
            return list;
        }

        public List<LoginModel> GetUsers()
        {
            List<LoginModel> loginModels = GetList();
            return loginModels;     
        }

    }

}