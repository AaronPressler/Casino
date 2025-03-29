using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaderBoardEntry
{
    public class LoginModel
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }
        public string Salt { get; set; }

        public int Points { get; set; }
        public Guid id { get; set; }


        public static explicit operator Player(LoginModel m)
        {
            if (m == null)
                return null;

            Player result = new Player();
            result.UserName = m.UserName;
            result.Password = m.Password;
            result.Points = m.Points;
            result.Salt = m.Salt;
            result.id = m.id;
            return result;
        }

        public static explicit operator LoginModel(Player m)
        {
            if (m == null)
                return null;

            LoginModel result = new LoginModel();
            result.UserName = m.UserName;
            result.Password = m.Password;
            result.Points = m.Points;
            result.Salt = m.Salt;
            result.id = m.id;
            return result;
        }
    }
}

