using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class Grp
    {
        public string Name { get; set; }
        public User[] Users { get; set; }

        public static Grp LoadFromXml(XElement xGrp)
        {
            var res = new Grp();
            res.Name = (string)xGrp.Attribute("name");

            res.Users = xGrp.Elements().Select(User.LoadFromXml).ToArray(); 

            return res;
        }
    }
}
