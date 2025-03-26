  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        
        public Guid id;
        public string UserName { get; set; }
        public string Password { get; set; }        
        public int Points { get; set; }
        public string Salt{ get; set; }

        public Player()
        {

        }
    }
}
