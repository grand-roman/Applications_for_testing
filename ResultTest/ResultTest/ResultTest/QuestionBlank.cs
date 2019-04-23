using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class QuestionBlank
    {
        public Question[] Questions { get; set; }
        public User ForUser { get; set; }
        public Grp ForGrp { get; set; }
        public int[][] GenAnswer { get; set; }


        public static QuestionBlank GenerateBlank(QuestionBank bank, int kol)
        {
            var GenRand = new double[kol];

            var res = new QuestionBlank();

            for (int i = 0; i < kol; i++)
                GenRand[i] = App.Rnd.NextDouble();

            res.GenAnswer = new int[kol][];
            for (int i = 0; i < kol; i++)
                res.GenAnswer[i] = Globals.Randoming(3);

            var tq = bank.Questions.ToArray();

            Array.Sort(GenRand, tq);

            res.Questions = tq.Take(kol).ToArray();

            return res;
        }

        public XElement SavePrepottToXml()
        {
            var xResU = new XElement("blankForPrepot");

            xResU.Add();

            var XResQ = new XElement("questions");


            for (int q = 0; q < Questions.Length; q++)
            {
                var XResQm = new XElement("question");    
                XResQm.Add(new XElement("id", Questions[q].Id));
                XResQm.Add(new XElement("answer", GenAnswer[q][0]));
                XResQ.Add(XResQm);
            }

            xResU.Add(XResQ);
            xResU.Add(ForUser.SaveToXml());

            return xResU;
        }

        public XElement SaveStudentToXml()
        {
            var xResU = new XElement("blank");

            var XResQ = new XElement("questions");

            for (int q = 0; q < Questions.Length; q++)
            {
                var XResQm = new XElement("question");
                XResQm.Add(new XElement("id", Questions[q].Id));
                XResQm.Add(new XElement("text", Questions[q].Text));
                XResQm.Add(new XElement("option", Questions[q].AnswerOptions[GenAnswer[q][0]]));
                XResQm.Add(new XElement("option", Questions[q].AnswerOptions[GenAnswer[q][1]]));
                XResQm.Add(new XElement("option", Questions[q].AnswerOptions[GenAnswer[q][2]]));
                XResQ.Add(XResQm);
            }

            xResU.Add(XResQ);
            xResU.Add(ForUser.SaveToXml());

            return xResU;
        }


    }
}
