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
        public User ForUser { get; set; }
        public string GuidRes { get; set; }

        public QuestionBlank()
        {
            Questions = new List<Question>();
        }

        public XElement SaveToXml()
        {
            var xRes = new XElement("Guid", GuidRes);

            return xRes;
        }

        public static QuestionBlank LoadFromXml(XElement ques)
        {
            var res = new QuestionBlank();
            foreach (var que in ques.Element("questions").Elements())
                res.Questions.Add(Question.LoadFromXml(que));
            res.ForUser = User.LoadFromXml(ques.Element("User"));
            res.GuidRes = (string)ques.Element("Guid");
            return res;
        }
    }
}
