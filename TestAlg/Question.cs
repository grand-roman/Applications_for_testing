using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TestAlg
{
    class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> AnswerOptions { get; set; }

        public Question()
        {
            AnswerOptions = new List<string>();
        }

        public static Question LoadFromXml(XElement Ques)
        {
            var res = new Question();
            res.Id = (int)Ques.Element("id");
            res.Text = (string)Ques.Element("text");
            res.AnswerOptions.Add((string)Ques.Element("answer"));
            foreach(string dis in Ques.Elements("distractor"))
                res.AnswerOptions.Add(dis);


            return res;
        }
    }


}
