// Importieren von benötigten Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using Casino.Models;
using Newtonsoft.Json;
using System.Web;
using System.Linq;
using Cards;
using System.Diagnostics;
using Game.Logik;
using System.Web.SessionState;
using MySql.Data.MySqlClient;

namespace Casino.Controllers
{
    public class CasinoController : Controller
    {
        // Verbindung zur MySQL-Datenbank
        MySqlConnection _connection = new MySqlConnection();

        // Kartenstapel und Kartenverwaltung
        public Stack<string> cardstack;
        public string[] aktivecards = new string[5];
        public List<string> pausedcards = new List<string>();

        // Kontrolliert, ob gezogen oder gegeben wird
        public static bool DrawOrDeal = true;

        // Instanz der Spiellogik
        Logic g = new Logic();

        #region Öffentliche Hilfsmethoden

        // Konvertiert eine Liste von LoginModel in LeaderBoardEntry.LoginModel
        public List<LeaderBoardEntry.LoginModel> Converttolist(List<LoginModel> list)
        {
            List<LeaderBoardEntry.LoginModel> list2 = new List<LeaderBoardEntry.LoginModel>();
            foreach (var item in list)
            {
                list2.Add((LeaderBoardEntry.LoginModel)item);
            }
            return list2;
        }

        // Lädt eine Liste der Benutzer
        public List<LoginModel> GetList()
        {
            List<LoginModel> list = new List<LoginModel>();
            List<LeaderBoardEntry.LoginModel> list2 = g.GetUsers();
            foreach (var item in list2)
            {
                list.Add((LoginModel)item);
            }
            return list;
        }

        #endregion

        #region Registrierung

        // Registrierung eines neuen Benutzers
        [HttpPost]
        public ActionResult Register(LoginModel model)
        {
            bool isnew = true;
            List<LoginModel> list = GetList();
            if (ModelState.IsValid)
            {
                // Prüfen, ob der Benutzername bereits existiert
                foreach (var item in list)
                {
                    if (item.UserName == model.UserName)
                    {
                        isnew = false;
                    }
                }
                // Neuen Benutzer hinzufügen
                if (isnew)
                {
                    g.AddNewUser(Converttolist(list), (LeaderBoardEntry.LoginModel)model);
                    return View("Login");
                }
            }
            return View(model);
        }

        // Registrierungsseite anzeigen
        public ActionResult Register()
        {
            return View();
        }
        #endregion

        #region Login

        // Benutzer-Login
        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            List<LoginModel> list = GetList();
            string pw = user.Password;
            string username = user.UserName;
            string salt = g.GetSalt(username); // Passwort-Salt holen

            // Benutzername und Passwort überprüfen
            foreach (var item in list)
            {
                if (username == item.UserName)
                {
                    if (Logic.VerifyPassword(user.Password, salt, item.Password))
                    {
                        Session["UserName"] = user.UserName;
                        return View("Settings");
                    }
                }
            }
            return View();
        }

        // Login-Seite anzeigen
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region Haupt-Webseite

        // Einstellungen-Seite
        public ActionResult Settings(LoginModel model)
        {
            var username = Session["Username"] as string;
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Casino");
            }
            return View(model);
        }

        // Punkte-Verwaltung
        [HttpGet]
        public ActionResult Points()
        {
            var username = Session["Username"] as string;
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Casino");
            }
            return View();
        }

        // Benutzer ausloggen
        public ActionResult Logout()
        {
            Session["Username"] = null;
            Model.poker = null;
            return View("Login");
        }

        // Benutzer-Datenbank leeren
        public ActionResult Clear()
        {
            if (_connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();

            _connection = new MySqlConnection("Server=62.178.173.135;Port=3306;Database=sew3_web_games;User ID=sew_db;Password=SewPassword123!;SslMode=none;;AllowPublicKeyRetrieval=True;");
            string query = "DELETE FROM user";
            _connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, _connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            _connection.Close();

            return View("Login");
        }

        // Punkte hinzufügen
        [HttpPost]
        public ActionResult Points(LoginModel model)
        {
            var username = Session["Username"] as string;
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Casino");
            }
            List<LoginModel> list = GetList();

            foreach (var item in list)
            {
                if (item.UserName == Session["UserName"].ToString())
                {
                    item.Points += model.Points;
                    break;
                }
            }

            g.SavePerson(Converttolist(list));
            ViewBag.Message = "Punkte wurden erfolgreich hinzugefügt!";
            return View("Settings", model);
        }
        #endregion

        #region Poker-Logik

        // Poker starten (POST)
        [HttpPost]
        public ActionResult Poker()
        {
            var username = Session["Username"] as string;
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Casino");

            Model.poker = new PokerModel();
            Card cards = new Card();

            List<LoginModel> list = GetList();
            Model.cardstack = cards.ReturnStack();

            // 5 Karten geben
            for (int i = 0; i < 5; i++)
            {
                aktivecards[i] = Model.cardstack.Peek();
                Model.cardstack.Pop();
            }

            string[] cardbacks = new string[5] { "CardBack", "CardBack", "CardBack", "CardBack", "CardBack" };
            Model.poker.Cards = cardbacks;
            Model.poker.Stake = 1;

            // Punkte setzen
            foreach (var item in list)
                if (item.UserName == Session["Username"].ToString())
                    Model.poker.Punkte = item.Points;

            Model.poker.LeaderBoard = g.FillLeaderBoard();
            Model.poker.heldcards = new List<string>();

            return View(Model.poker);
        }

        // Poker starten (GET, z.B. bei ungültigem Aufruf)
        [HttpGet]
        public ActionResult Poker(string signatur)
        {
            var username = Session["Username"] as string;
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Casino");

            return View("Login");
        }

        // Karten anzeigen: entweder "Deal" oder "Draw"
        [HttpGet]
        public ActionResult DisplayCards()
        {
            if (DrawOrDeal)
            {
                DrawOrDeal = false;
                Model.poker.ButtonName = "Draw";

                if ((Model.poker.Punkte - 10 * Model.poker.Stake) <= 0)
                {
                    LoginModel lm = new LoginModel();
                    lm.Error = "Sie haben nicht mehr genug Punkte zum Weiterspielen.";
                    return View("Points", lm);
                }
                return View("Poker", Deal());
            }
            else
            {
                Model.poker.ButtonName = "Deal";
                DrawOrDeal = true;
                return View("Poker", Draw());
            }
        }

        // Erste 5 Karten geben ("Deal")
        public PokerModel Deal()
        {
            Card cards = new Card();
            string[] dealcards = new string[5];
            List<LoginModel> users = GetList();

            Model.poker.Punkte -= 10 * Model.poker.Stake;

            foreach (var user in users)
            {
                if (user.UserName == Session["Username"].ToString())
                    user.Points = Model.poker.Punkte;
            }
            g.SavePerson(Converttolist(users));

            Model.poker.heldcards = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                if (Model.cardstack.Count <= 5)
                    Model.cardstack = cards.ReturnStack();

                dealcards[i] = Model.cardstack.Peek();
                Model.cardstack.Pop();
            }
            Model.poker.Cards = dealcards;
            return Model.poker;
        }

        // Karten tauschen ("Draw")
        public PokerModel Draw()
        {
            List<string> dealcards = new List<string>();

            foreach (var item in Model.poker.heldcards)
            {
                if (item != null)
                    dealcards.Add(item);
            }

            for (int i = 5 - dealcards.Count; i > 0; i--)
            {
                dealcards.Add(Model.cardstack.Peek());
                Model.cardstack.Pop();
            }

            Model.poker.Cards = dealcards.ToArray();
            Model.poker.LatestErnings = g.GetPoints(Model.poker.Cards, Model.poker.Stake);
            Model.poker.Punkte += g.SperatePointsFromString(Model.poker.LatestErnings);

            return Model.poker;
        }

        // Karte "halten" (bzw. nicht tauschen beim Draw)
        [HttpPost]
        public ActionResult HoldCard(PokerCard pc)
        {
            if (Model.poker.heldcards == null)
                Model.poker.heldcards = new List<string>();

            for (int i = 0; i < Model.poker.heldcards.Count; i++)
            {
                if (Model.poker.heldcards[i] == pc.Card)
                {
                    Model.poker.heldcards[i] = null;
                    return View("Poker", Model.poker);
                }
            }

            Model.poker.heldcards.Add(pc.Card.ToString());
            return View("Poker", Model.poker);
        }

        // Karten neu geben
        public ActionResult GiveoutCards()
        {
            for (int i = 0; i < 5; i++)
            {
                aktivecards[i] = cardstack.Peek();
                cardstack.Pop();
            }
            return View("Poker");
        }

        // Karten wechseln (nach Pause oder ähnlichem)
        public ActionResult ChangeCards()
        {
            for (int i = 0; i < pausedcards.Count(); i++)
                aktivecards[i] = pausedcards[i];

            for (int i = pausedcards.Count(); i < 5; i++)
            {
                aktivecards[i] = cardstack.Peek();
                cardstack.Pop();
            }

            Model.poker = new PokerModel();
            Card cards = new Card();
            List<LoginModel> list = GetList();

            foreach (var item in list)
                if (item.UserName == Session["Username"].ToString())
                    Model.poker.Punkte = item.Points;

            Model.poker.LeaderBoard = g.FillLeaderBoard();
            Model.poker.Cards = aktivecards;
            Model.poker.Stake = 1;

            return View("Poker");
        }

        // Einsatz erhöhen
        public ActionResult UpStake()
        {
            if (DrawOrDeal)
                Model.poker.Stake++;
            return View("Poker", Model.poker);
        }

        // Einsatz setzen
        public ActionResult SetStake(int amount)
        {
            if (DrawOrDeal && amount > 0 && amount <= Model.poker.Punkte / 10)
                Model.poker.Stake = amount;
            return View("Poker", Model.poker);
        }

        // Einsatz verringern
        public ActionResult DownStake()
        {
            if (DrawOrDeal)
                if (Model.poker.Stake > 1)
                    Model.poker.Stake--;
            return View("Poker", Model.poker);
        }

        #endregion

        // Zugriff auf das Session-Model
        protected SessionModel Model
        {
            get
            {
                SessionModel result = Session["PokerModel"] as SessionModel;
                if (result == null)
                {
                    result = new SessionModel();
                    Session.Add("PokerModel", result);
                }
                return result;
            }
        }
    }
}
