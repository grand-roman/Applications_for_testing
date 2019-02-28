using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TestAlg
{
    class TestViewModel : INotifyPropertyChanged
    {
        private MyCommand IKnow { get; set; }
        private MyCommand IDontKnow { get; set; }

        int[] answerShuffle;

        public string QuestionText
        {
            get
            {
                return CurrenQuestion.Text;

            }
        }

        public string QuestionAndswer1
        {
            get
            {
                return CurrenQuestion.AnswerOptions[answerShuffle[0]];
            }
        }

        public string QuestionAndswer2
        {
            get
            {
                return CurrenQuestion.AnswerOptions[answerShuffle[1]];

            }
        }

        public string QuestionAndswer3
        {
            get
            {
                return CurrenQuestion.AnswerOptions[answerShuffle[2]];

            }
        }




        public int SliderMaximum
        {
            get { return lenQuestion; }

            set{
                lenQuestion = value;
                OnPropertyChanged("SliderMaximum"); }
            
        }



        public int SliderValue
        {
            get { return currenQuestionIndex; }
            set {
                currenQuestionIndex = value;
                OnPropertyChanged("SliderValue");
                RunForAnswer();
            }
        }



        List<Probe> questions;

        int currenQuestionIndex;
        int lenQuestion;

        Probe CurrenQuestion
        {
            get
            {
                return questions[currenQuestionIndex];
            }
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand IKnowCommand { get { return IKnow; } }
        public ICommand IDontKnowCommand { get { return IDontKnow; } }

        public TestViewModel(List<Probe> questions)
        {
            IKnow = new MyCommand(this);
            IKnow.Operation = SureAnswer;
            IDontKnow = new MyCommand(this);
            IDontKnow.Operation = NotSureAnswer;
            this.questions = questions;
            currenQuestionIndex = 0;
            lenQuestion = questions.Count - 1;
            answerShuffle = Randoming(3);
        }

        void SureAnswer()
        {

            currenQuestionIndex++;
            OnPropertyChanged("QuestionText");
            OnPropertyChanged("QuestionAndswer1");
            OnPropertyChanged("QuestionAndswer2");
            OnPropertyChanged("QuestionAndswer3");

        }

        void NotSureAnswer()
        {
            currenQuestionIndex++;
            OnPropertyChanged("QuestionText");
            OnPropertyChanged("QuestionAndswer1");
            OnPropertyChanged("QuestionAndswer2");
            OnPropertyChanged("QuestionAndswer3");
        }

        void RunForAnswer()
        {
            OnPropertyChanged("QuestionText");
            OnPropertyChanged("QuestionAndswer1");
            OnPropertyChanged("QuestionAndswer2");
            OnPropertyChanged("QuestionAndswer3");
        }



        public static int[] Randoming(int count)
        {
            var rnd = new Random((int)DateTime.Now.ToBinary());

            var m = new int[count];
            var mk = new double[count];

            for (int i = 0; i < count; i++)
            {
                m[i] = i;
                mk[i] = rnd.NextDouble();
            }

            Array.Sort(mk, m);

            return m;
        }

    }

    class MyCommand : ICommand
    {
        private TestViewModel model;
        public Action Operation { get; set; }

        public MyCommand(TestViewModel model)
        {
            this.model = model;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Operation();
        }
    }





}
