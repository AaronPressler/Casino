using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Casino.Models
{
    public class LoginModel
    {
        [DisplayName("Benutzername")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Alter")]
        [Required]
        public int Age { get; set; }

        [DisplayName("Punkte")]
        public int Points { get; set; }

        public string Salt { get; set; }



        public static explicit operator LeaderBoardEntry.LoginModel(LoginModel m)
        {
            if (m == null)
                return null;

            LeaderBoardEntry.LoginModel result = new LeaderBoardEntry.LoginModel();
            result.UserName = m.UserName;
            result.Password = m.Password;
            result.Points = m.Points;
            result.Age = m.Age;
            result.Salt = m.Salt;
            return result;
        }

        public static explicit operator LoginModel( LeaderBoardEntry.LoginModel m)
        {
            if (m == null)
                return null;

            LoginModel result = new LoginModel();
            result.UserName = m.UserName;
            result.Password = m.Password;
            result.Points = m.Points;
            result.Age = m.Age;
            result.Salt = m.Salt;
            return result;
        }
    }
}