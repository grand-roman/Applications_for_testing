﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlg
{
    class Probe : INotifyPropertyChanged
    {
        int[] answerShuffle;
        public Probe()
        {
            answerShuffle = Globals.Randoming(3);
        }
        public string QuestionText
        {
            get
            {
                return Question.Text;

            }
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
                //enabled = false;
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
                //enabled = false;
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


        //private bool enabled = true;
        //public bool Enabled
        //{
        //    get
        //    {
        //        return enabled;
        //    }

        //    set
        //    {
        //        OnPropertyChanged("Enabled");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    
}
