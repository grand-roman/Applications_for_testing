using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    public class User
    {
        public string FName { get; set; }
        public string IName { get; set; }
        public string OName { get; set; }

        public static User LoadFromXml(XElement xUser)
        {
            var res = new User();
            res.FName = (string)xUser.Attribute("f");
            res.IName = (string)xUser.Attribute("i");
            res.OName = (string)xUser.Attribute("o");

            return res;
        }

        public XElement SaveToXml()
        {
            var xResU = new XElement("User");

            xResU.Add(new XAttribute("f", FName));
            xResU.Add(new XAttribute("i", IName));
            xResU.Add(new XAttribute("o", OName));

            return xResU;
        }
    }
}
