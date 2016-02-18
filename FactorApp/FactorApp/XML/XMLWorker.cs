using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using FactorApp.AuthorizationLogic;
using FactorApp.Security;

namespace FactorApp.XML
{
    public enum BaseTypes {Users,Main}

    class XMLWorker
    {
        protected string filePath;
        protected XDocument document;
        protected DataCrypto cryptoWorker;
        protected UnicodeEncoding encoder;
        public XDocument Document { get { return document; } }

        public XMLWorker(XDocument xdoc)
        {
            document = xdoc;
            filePath = "C:\tmp.xml";
            cryptoWorker = new DataCrypto();
            encoder = new UnicodeEncoding();
        }

        public XMLWorker(string xmlFile)
        {
            filePath = xmlFile;
            cryptoWorker = new DataCrypto();
            encoder = new UnicodeEncoding();
            if(!File.Exists(xmlFile))
            {
                CreateNewDocument(xmlFile);
            }
            document = document ?? XDocument.Load(xmlFile);
        }

        protected virtual void CreateNewDocument(string xmlFile)
        {
            XDocument doc = new XDocument();
            doc.Save(xmlFile);
        }

        public virtual void Add(object value)
        {
            document.Root.Add(value);
        }

        public virtual void Delete(object value)
        {

        }

    }

    class UsersBaseClass : XMLWorker
    {
       
        private RightsType rights;
        public RightsType Rights { get { return rights; } }
        private IEnumerable<XElement> user;

        public UsersBaseClass(string xmlFile)
            : base(xmlFile)
        {
            rights = RightsType.Watch;
        }

        protected override void CreateNewDocument(string xmlFile)
        {
            document = new XDocument();
            List<XAttribute> attr = new List<XAttribute>();
            RightsType defaultRight = RightsType.Administration;
            string defaultLogIn = "Administrator";
            string defaultPassword = "Adm";
            document.Add(new XElement("UsersBase"));
            Add(defaultLogIn, defaultPassword, defaultRight);
        }
        
        private string ByteArrayToString(byte[] array)
        {
            return encoder.GetString(array);
        }

        public bool IsValidLogIn(string logIn)
        {
            user =
                from el in document.Root.Elements("User")
                where (string)cryptoWorker.AesDataDecrypt((new UnicodeEncoding()).GetBytes(el.Attribute("LogIN").Value)) == logIn
                select el;
            if (user.ToList().Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidPassword(string logIn, string password)
        {
            bool result = false;

            if(IsValidLogIn(logIn))
            {
                foreach (XElement elm in user)
                {
                    if (elm.Attribute("Password").Value == encoder.GetString(cryptoWorker.HashPasswordEncrypt(password)))
                    {
                        rights =(RightsType)Enum.Parse(typeof(RightsType),(string)cryptoWorker.AesDataDecrypt(encoder.GetBytes(elm.Attribute("Rights").Value)));
                        result = true;
                    }
                   
                }
            }
            return result;
        }

        public void Add(string logIn, string password, RightsType rights)
        {
            List<XAttribute> attr = new List<XAttribute>();
            attr.Add(new XAttribute("LogIN", encoder.GetString(cryptoWorker.AesDataEncrypt(logIn))));
            attr.Add(new XAttribute("Password", encoder.GetString(cryptoWorker.HashPasswordEncrypt(password))));
            attr.Add(new XAttribute("Rights", encoder.GetString(cryptoWorker.AesDataEncrypt(rights))));
            document.Root.Add(new XElement("User", attr));
            document.Save(filePath);
        }

        public void Delete(string logIn)
        {
            document.Root.Elements().First(x => (string)cryptoWorker.AesDataDecrypt(encoder.GetBytes(x.Attribute("LogIN").Value)) == logIn).Remove();
            document.Save(filePath);
        }

        public void Edit(string logIn, string password, List<RightsType> rights)
        {

        }

        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();
            user =
                from el in document.Root.Elements("User")
                select el;
            foreach (XElement el in user)
            {
                result.Add(new User((string)cryptoWorker.AesDataDecrypt(encoder.GetBytes(el.Attribute("LogIN").Value)),(RightsType)Enum.Parse(typeof(RightsType),(string)cryptoWorker.AesDataDecrypt(encoder.GetBytes(el.Attribute("Rights").Value)))));
            }
            return result;
        }

    }


}
