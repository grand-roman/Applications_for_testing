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

        public Probe CurrenQuestion
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
        }

        void SureAnswer()
        {
            CurrenQuestion.SureBut(true);
            if (currenQuestionIndex == lenQuestion)
            {
                currenQuestionIndex = 0;
            }
            else
            {
                currenQuestionIndex++;
            }
            OnPropertyChanged("CurrenQuestion");
            OnPropertyChanged("SliderValue");
        }

        void NotSureAnswer()
        {
            CurrenQuestion.NotSureBut(true);
            if (currenQuestionIndex == lenQuestion)
            {
                currenQuestionIndex = 0;
            }
            else
            {
                currenQuestionIndex++;
            }
            OnPropertyChanged("CurrenQuestion");
            OnPropertyChanged("SliderValue");
        }

        void RunForAnswer()
        {
            OnPropertyChanged("CurrenQuestion");
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
