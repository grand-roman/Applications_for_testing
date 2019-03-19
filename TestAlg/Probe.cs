using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestAlg
{
    class Probe : INotifyPropertyChanged
    {
        int[] answerShuffle;
        public Probe()
        {
            answerShuffle = Globals.Randoming(3);
        }

        public string QuestionAndswer1
        {
            get
            {
                return Question.AnswerOptions[answerShuffle[0]];
            }
        }

        public string QuestionAndswer2
        {
            get
            {
                return Question.AnswerOptions[answerShuffle[1]];

            }
        }

        public string QuestionAndswer3
        {
            get
            {
                return Question.AnswerOptions[answerShuffle[2]];

            }
        }

        public Question Question { get; set; }

        bool andswer1 = false;
        public bool Andswer1
        {
            get
            {
                return andswer1;
            }

            set
            {
                andswer1 = value;
                if (value)
                {
                    Andswer2 = false;
                    Andswer3 = false;
                    sure = true;
                    notSure = true;
                }
                OnPropertyChanged("Andswer1");
                OnPropertyChanged("Sure");
                OnPropertyChanged("NotSure");
            }
        }

        bool andswer2 = false;
        public bool Andswer2
        {
            get
            {
                return andswer2;
            }

            set
            {
                andswer2 = value;
                if (value)
                {
                    Andswer1 = false;
                    Andswer3 = false;
                    sure = true;
                    notSure = true;
                }
                OnPropertyChanged("Andswer2");
                OnPropertyChanged("Sure");
                OnPropertyChanged("NotSure");
            }
        }

        bool andswer3 = false;
        public bool Andswer3
        {
            get
            {
                return andswer3;
            }

            set
            {
                andswer3 = value;
                if (value)
                {
                    Andswer1 = false;
                    Andswer2 = false;
                    sure = true;
                    notSure = true;
                }
                OnPropertyChanged("Andswer3");
                OnPropertyChanged("Sure");
                OnPropertyChanged("NotSure");
            }
        }

        private bool sure = true;
        public bool SureBut(bool it = false)
        {

            if (it)
            {
                sure = false;
            }
            return sure;
        }

        public bool Sure
        {
            get
            {
                return sure;
            }

            set
            {
                OnPropertyChanged("Sure");
            }
        }

        private bool notSure = true;
        public bool NotSureBut(bool it = false)
        {

            if (it)
            {
                notSure = false;
            }
            return notSure;
        }
        public bool NotSure
        {
            get
            {
                return notSure;
            }

            set
            {
                OnPropertyChanged("NotSure");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public XElement SaveToXml()
        {
            var xRes = new XElement("result");

            xRes.Add(new XElement("id", Question.Id));
            if (Andswer1 == true) xRes.Add(new XElement("answer", answerShuffle[0]));
            else if (Andswer2 == true) xRes.Add(new XElement("answer", answerShuffle[1]));
            else if (Andswer3 == true) xRes.Add(new XElement("answer", answerShuffle[2]));
            if (notSure == false) xRes.Add(new XElement("option", "notSure"));
            else if (Sure == false) xRes.Add(new XElement("option", "Sure"));



            return xRes;
        }
    }
    
}
