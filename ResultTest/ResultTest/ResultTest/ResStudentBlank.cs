using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class ResStudentBlank
    {
        public List<ResStudent> Ress { get; set; }

        public string User { get; set; }

        public ResStudentBlank()
        {
            Ress = new List<ResStudent>();
        }

        public static ResStudentBlank LoadFromXml(XElement Ques)
        {
            if (Ques != null)
            {
                var res = new ResStudentBlank();
                foreach (var ques in Ques.Elements())
                    foreach (var que in ques.Elements())
                        res.Ress.Add(ResStudent.LoadFromXml(que));

                res.User = "Решение от" + (string)Ques.Element("User").Attribute("f") + " "
                       + (string)Ques.Element("User").Attribute("i") + " "
                       + (string)Ques.Element("User").Attribute("o");

                return res;
            }
            return null;
        }
    }
}
