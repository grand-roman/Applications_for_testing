﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class ResStudent
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public string Option { get; set; }

        public static ResStudent LoadFromXml(XElement Ques)
        {
            var res = new ResStudent();
            res.Id = (int)Ques.Element("id");
            res.Answer = (string)Ques.Element("answer");
            res.Option = (string)Ques.Element("option");

            return res;
        }
    }
}
