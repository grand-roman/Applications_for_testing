using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class KeyBlank
    {
        public List<KeyStudent> Keys { get; set; }

        public string User { get; set; }



        public KeyBlank()
        {
            Keys = new List<KeyStudent>();
        }

        public static KeyBlank LoadFromXml(XElement Ques)
        {
            if (Ques != null)
            {
                var res = new KeyBlank();
                foreach (var ques in Ques.Elements())
                    foreach (var que in ques.Elements())
                        res.Keys.Add(KeyStudent.LoadFromXml(que));

                res.User = "Ключ для " + (string)Ques.Element("User").Attribute("f") + " "
                        + (string)Ques.Element("User").Attribute("i") + " "
                        + (string)Ques.Element("User").Attribute("o");

                return res;
            }
            return null;
        }
    }
}
