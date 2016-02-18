using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using FactorApp.XML;

namespace FactorApp.AuthorizationLogic
{
    class Authorization
    {

        private UsersBaseClass xWorker;
        private int attempts;
        public int Attepmpts { get{return attempts;}}
        public RightsType UserRights { get { return xWorker.Rights; } }

        public Authorization(string path)
        {
            attempts = 0;
            xWorker = new UsersBaseClass(path);
        }

        public LogInErrorType CheckPassword(string logIn, string password)
        {
            LogInErrorType result = LogInErrorType.Passed;
            if (xWorker.IsValidLogIn(logIn))
            {
                if (xWorker.IsValidPassword(logIn, password))
                {  
                    result = LogInErrorType.Passed;
                }
                else
                {
                    result = LogInErrorType.WrongPassword;
                }
            }
            else
            {
                result = LogInErrorType.WrongLogIn;
            }
            attempts += 1;
            return result;
        }


    }

    enum LogInErrorType { WrongLogIn, WrongPassword, Passed };


}
