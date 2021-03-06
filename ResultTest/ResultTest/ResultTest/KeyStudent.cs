﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ResultTest
{
    class KeyStudent
    {
        public int Id { get; set; }
        public string Answer { get; set; }

        public static KeyStudent LoadFromXml(XElement Ques)
        {
            var res = new KeyStudent();
            res.Id = (int)Ques.Element("id");
            res.Answer = (string)Ques.Element("answer");

            return res;
        }
    }
}
