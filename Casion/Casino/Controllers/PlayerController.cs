using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.SessionState;
using Cards;
using Casino.Models;
using Domain;
using Game.Logik;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Parameters;

namespace Casino.Controllers
{

    public class PlayerController : Controller
    {


        // GET: /Player/GetUserData
        [System.Web.Mvc.HttpGet]
        public JsonResult GetUserData()
        {
            var users = GetList();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        private List<LeaderBoardEntry.LoginModel> GetLeaderBoardUserList()
        {
            Logic g = new Logic();
            List<LeaderBoardEntry.LoginModel> list = new List<LeaderBoardEntry.LoginModel>();
            list = g.GetUsers();
            return list; // Liefert List<LeaderBoardEntry.LoginModel>
        }
        // POST: /Player/Register
        [System.Web.Mvc.HttpPost]
        public JsonResult Register(LeaderBoardEntry.LoginModel model)
        {
            bool success = false;
            string message;

            try
            {
                var list = GetLeaderBoardUserList();
                // Prüfe, ob User bereits existiert
                var exists = list.Any(u => u.UserName == model.UserName);
                if (exists)
                {
                    message = "Benutzername existiert bereits!";
                }
                else
                {
                    Logic g = new Logic();
                    g.AddNewUser(list, model);
                    success = true;
                    message = "Registrierung erfolgreich";
                }
            }
            catch (Exception ex)
            {
                message = "Fehler: " + ex.Message;
            }
            return Json(new { success, message });
        }


        // POST: /Player/Login
        [System.Web.Mvc.HttpPost]
        public JsonResult Login(LeaderBoardEntry.LoginModel model)
        {
            bool success = false;
            string message;

            try
            {
                var list = GetLeaderBoardUserList();
                var user = list.FirstOrDefault(u => u.UserName == model.UserName);

                if (user != null)
                {
                    // Passwort prüfen (Hash + Salt)
                    if (Game.Logik.Logic.VerifyPassword(model.Password, user.Salt, user.Password))
                    {
                        success = true;
                        message = "Login erfolgreich";
                    }
                    else
                    {
                        message = "Benutzername oder Passwort falsch";
                    }
                }
                else
                {
                    message = "Benutzername oder Passwort falsch";
                }
            }
            catch (Exception ex)
            {
                message = "Fehler: " + ex.Message;
            }
            return Json(new { success, message });
        }

        // POST: /Player/UpdatePlayer
        [System.Web.Mvc.HttpPost]
        public JsonResult UpdatePlayer(LoginModel model)
        {
            // Hier: Aktualisiere die Benutzerdaten
            // Beispiel: Logic.UpdateUser(model);
            bool success = true; // Setze dies nach deiner Logik
            string message = "Update erfolgreich";
            return Json(new { success, message });
        }

        // Hilfsmethode: Alle User abrufen
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


    }

}