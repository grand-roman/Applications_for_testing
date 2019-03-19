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

        public XElement SaveToXml()
        {
            var xRes = new XElement("User");

            xRes.Add(new XElement("FirstName", FirstName));
            xRes.Add(new XElement("LastName", LastName));
            xRes.Add(new XElement("Grade", Grade));
            return xRes;
        }
    }
}
