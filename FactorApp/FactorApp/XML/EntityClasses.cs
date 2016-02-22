using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorApp.XML
{
    class User
    {
        private int id;
        public int ID { get { return id; } }
        private string logIn;
        public string LogIN { get { return logIn;} }
        private string password;
        public string Password { get { return password; } }
        private RightsType rights;
        public RightsType Rights { get { return rights; } }

        public User()
        {
            id = -1;
            logIn = "None";
            password = "***";
            rights = RightsType.Watch;
        }

        public User(int inpId, string inpLogIn, string inpPassword, RightsType inpRights)
        {
            id = inpId;
            logIn = inpLogIn;
            rights = inpRights;
            if (string.IsNullOrEmpty(inpPassword))
            {
                password = string.Empty;
            }
            else
            {
                password = "***";
            }

        }

    }
}
