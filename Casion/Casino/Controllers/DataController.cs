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

namespace Casino.Controllers
{
   

    public class PlayerController : Controller
    {
        private readonly DataL _dataLayer;

        public PlayerController()
        {
            _dataLayer = new MyDataLayer();
        }

        [HttpPost]
        [Route("api/player/save")]
        public IHttpActionResult SavePlayer(Player player)
        {
            if (player == null)
                return BadRequest();

            // Einzeln speichern
            _dataLayer.SavePersons(new List<Player> { player });

            return Ok("Player gespeichert!");
        }
    }

}