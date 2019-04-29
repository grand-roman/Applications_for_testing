using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class InteractiveTestService : ITestService
    {
        void ITestService.Generate(string studentPath, string bankPath, string outputFolder)
        {
            Guid g;
            XElement xml = XElement.Load(bankPath);
            XElement xmlU = XElement.Load(studentPath);
            var grp = Grp.LoadFromXml(xmlU);
            var questionBank = QuestionBank.LoadFromXml(xml);
            var questionBLank = QuestionBlank.GenerateBlank(questionBank, 3);

            foreach (User student in grp.Users) {
                questionBLank.ForUser = student;

                var p = questionBLank.SavePrepottToXml();
                var s = questionBLank.SaveStudentToXml();

                g = Guid.NewGuid();
                var XGuid = new XElement("Guid");
                XGuid.Add(g);
                p.Add(XGuid);
                s.Add(XGuid);

                var chpath = Path.Combine(outputFolder, "Check");
                var stpath = Path.Combine(outputFolder, "KR");

                Directory.CreateDirectory(stpath);
                Directory.CreateDirectory(chpath);

                var chpatsh = string.Format("{0} {1} {2} CheckKR.xml", student.FName, student.IName, student.OName);
                var stpatsh = string.Format("{0} {1} {2} KR.xml", student.FName, student.IName, student.OName);

                p.Save(System.IO.Path.Combine(chpath, chpatsh));

                s.Save(System.IO.Path.Combine(stpath, stpatsh));
            }
        }

        //static IEnumerable<Tuple<XElement, XElement>> MatchKeysToResult(IEnumerable<XElement> xx)
        //{


        //}

        //void ITestService.ResultScore(string resPath, string resPath)
        //{
        //    XElement xmlRes = XElement.Load(resPath);

        //    XElement xmlKey = XElement.Load(keyPath);

        //    var resStudent = ResStudent.LoadFromXml(xml);




        //    IEnumerable<XElement> res;

        //    XElement tres = XElement.Load(resPath);

        //    res.Append<XElement>(tres);


        //}
    }
}
