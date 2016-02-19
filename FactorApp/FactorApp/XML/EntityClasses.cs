using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorApp.XML
{
    class User
    {
        private string logIn;
        public string LogIN { get { return logIn;} }
        private string password;
        public string Password { get { return password; } }
        private RightsType rights;
        public RightsType Rights { get { return rights; } }

        public User()
        {
            logIn = "None";
            rights = RightsType.Watch;
        }

        public User(string inpLogIn, RightsType inpRights)
        {
            logIn = inpLogIn;
            rights = inpRights;
            password = "***";
        }

        public User(string inpLogIn, string inpPassword, RightsType inpRights)
        {
            logIn = inpLogIn;
            password = inpPassword;
            rights = inpRights;
        }
    }
}
