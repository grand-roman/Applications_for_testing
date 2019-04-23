using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestAlg
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }

        public User()
        {
            ;
        }
        
        public static User LoadFromXml(XElement xUser)
        {
            var res = new User();
            res.FirstName = (string)xUser.Attribute("f");
            res.LastName = (string)xUser.Attribute("i");
            res.Grade = (string)xUser.Attribute("o");

            return res;
        }

        public XElement SaveToXml()
        {
            var xRes = new XElement("User");

            xRes.Add(new XAttribute("f", FirstName));
            xRes.Add(new XAttribute("i", LastName));
            xRes.Add(new XAttribute("o", Grade));
            return xRes;
        }
    }
}
