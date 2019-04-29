using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class QuestionBank
    {
        public List<Question> Questions { get; set; }

        public QuestionBank()
        {
            Questions = new List<Question>();
        }

        public static QuestionBank LoadFromXml(XElement Ques)
        {
            var res = new QuestionBank();
            foreach (var ques in Ques.Elements())

                res.Questions.Add(Question.LoadFromXml(ques));

            return res;
        }

       
    }
}
