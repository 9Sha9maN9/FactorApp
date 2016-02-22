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
        public DataCrypto CryptoWorker { get { return cryptoWorker; } }
        public XDocument Document { get { return document; } }

        public XMLWorker(XDocument xdoc)
        {
            document = xdoc;
            filePath = "C:\tmp.xml";
            cryptoWorker = new DataCrypto();
        }

        public XMLWorker(string xmlFile)
        {
            filePath = xmlFile;
            cryptoWorker = new DataCrypto();
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
            document.Add(new XElement("UsersBase", new XAttribute("Id", 0)));
            Add(defaultLogIn, defaultPassword, defaultRight);
        }

        public bool IsValidLogIn(string logIn)
        {
            user = (from el in document.Root.Elements("User")
                    where (string)cryptoWorker.AesDataDecrypt(DataCrypto.GetBytes(el.Attribute("LogIN").Value)) == logIn
                    select el);
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
                    if (elm.Attribute("Password").Value == new UnicodeEncoding().GetString(cryptoWorker.HashPasswordEncrypt(password)))
                    {
                        rights =(RightsType)Enum.Parse(typeof(RightsType),(string)cryptoWorker.AesDataDecrypt(DataCrypto.GetBytes(elm.Attribute("Rights").Value)));
                        result = true;
                    }
                   
                }
            }
            return result;
        }

        public void Add(string logIn, string password, RightsType rights)
        {
            List<XAttribute> attr = new List<XAttribute>();
            attr.Add(new XAttribute("Id", GetLastId()));
            attr.Add(new XAttribute("LogIN", DataCrypto.GetString(cryptoWorker.AesDataEncrypt(logIn))));
            attr.Add(new XAttribute("Password", new UnicodeEncoding().GetString(cryptoWorker.HashPasswordEncrypt(password))));
            attr.Add(new XAttribute("Rights", DataCrypto.GetString(cryptoWorker.AesDataEncrypt(rights))));
            document.Root.Add(new XElement("User", attr));
            SetLastId();
            document.Save(filePath);
        }

        public void Delete(int id)
        {
            document.Root.Elements().First(x=> int.Parse(x.Attribute("Id").Value)==id).Remove();
            document.Save(filePath);
        }

        public void Edit(int id,string logIn, string password, RightsType rights)
        {
            XElement tmp = document.Root.Elements().First(x => int.Parse(x.Attribute("Id").Value) == id);
            tmp.Attribute("LogIN").Value=DataCrypto.GetString(cryptoWorker.AesDataEncrypt(logIn));
            tmp.Attribute("Password").Value = new UnicodeEncoding().GetString(cryptoWorker.HashPasswordEncrypt(password));
            tmp.Attribute("Rights").Value = DataCrypto.GetString(cryptoWorker.AesDataEncrypt(rights));
            document.Save(filePath);
        }

        public void Edit(int id, string logIn, RightsType rights)
        {
            XElement tmp = document.Root.Elements().First(x => int.Parse(x.Attribute("Id").Value) == id);
            tmp.Attribute("LogIN").Value = DataCrypto.GetString(cryptoWorker.AesDataEncrypt(logIn));
            tmp.Attribute("Rights").Value = DataCrypto.GetString(cryptoWorker.AesDataEncrypt(rights));
            document.Save(filePath);
        }

        public List<User> GetAllUsers()
        {
            List<User> result = new List<User>();
            user =
                from el in document.Root.Elements("User")
                select el;
            foreach (XElement el in user)
            {
                result.Add(new User(int.Parse(el.Attribute("Id").Value),(string)cryptoWorker.AesDataDecrypt(DataCrypto.GetBytes(el.Attribute("LogIN").Value)),
                    el.Attribute("Password").Value,
                    (RightsType)Enum.Parse(typeof(RightsType),
                    (string)cryptoWorker.AesDataDecrypt(DataCrypto.GetBytes(el.Attribute("Rights").Value)))));
            }
            return result;
        }

        public int GetLastId()
        {
            return int.Parse(document.Root.Attribute("Id").Value);
        }

        private void SetLastId()
        {
            int value = GetLastId();
            value += 1;
            document.Root.Attribute("Id").Value = value.ToString();
        }

    }


}
