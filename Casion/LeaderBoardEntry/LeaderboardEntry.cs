using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardEntry
{
    public class LeaderboardEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public LeaderboardEntry(int score, string playername)
        {
            PlayerName = playername;
            Score = score;
        }

    }
}
