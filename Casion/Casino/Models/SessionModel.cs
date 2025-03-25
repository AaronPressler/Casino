using Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Casino.Models
{
    public class SessionModel
    {
        public PokerModel poker { get; set; }
        public Stack<string> cardstack{ get; set; }   
        
        public LoginModel login { get; set; }
    }
}