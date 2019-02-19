using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestAlg
{
    class QuestionBlank
    {
        public List<Question> Questions { get; set; }

        public QuestionBlank()
        {
            Questions = new List<Question>();
        }

        public static QuestionBlank LoadFromXml(XElement Ques)
        {
            var res = new QuestionBlank();
            foreach (var ques in Ques.Elements())

                res.Questions.Add(Question.LoadFromXml(ques));

            return res;
        }
    }
}
