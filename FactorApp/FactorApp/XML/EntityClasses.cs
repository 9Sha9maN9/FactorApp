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
        private RightsType right;
        public RightsType Right { get { return right; } }

        public User()
        {
            logIn = "None";
            right = RightsType.Watch;
        }

        public User(string inpLogIn, RightsType inpRight)
        {
            logIn = inpLogIn;
            right = inpRight;
        }
    }
}
