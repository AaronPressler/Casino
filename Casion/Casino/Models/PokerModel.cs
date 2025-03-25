using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using LeaderBoardEntry;


namespace Casino.Models
{
   

    public class PokerCard
    {
        public string Card { get; set; }
    }

    public class PokerModel
    {
        public int Stake { get; set; }
        public string[] Cards { get; set; }
        public int Punkte { get; set; }
        public string LatestErnings { get; set; }
        public List<LeaderboardEntry> LeaderBoard { get; set; }
        public List<string> heldcards { get; set; }

        public string ButtonName { get; set; }
    }

}