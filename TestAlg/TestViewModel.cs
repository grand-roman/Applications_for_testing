using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Linq;

namespace TestAlg
{
    class TestViewModel : INotifyPropertyChanged
    {
        Action onDone;

        DispatcherTimer timer;
        

        private MyCommand IKnow { get; set; }
        private MyCommand IDontKnow { get; set; }
        private MyCommand IDone { get; set; }

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

        public TimeSpan MyTime
        {
            get;
            set;
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
        public ICommand IDoneCommand { get { return IDone; } }

        public TestViewModel(List<Probe> questions, Action onDone)
        {
            this.onDone = onDone;
            IKnow = new MyCommand(this);
            IKnow.Operation = SureAnswer;
            IDontKnow = new MyCommand(this);
            IDontKnow.Operation = NotSureAnswer;
            IDone = new MyCommand(this);
            IDone.Operation = DoneAnswer;
            this.questions = questions;
            currenQuestionIndex = 0;
            lenQuestion = questions.Count - 1;

            timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (MyTime.TotalSeconds >= 1800)
            {
                timer.Stop();
                onDone();
            }
            else
            {
                MyTime += TimeSpan.FromSeconds(1);
                OnPropertyChanged("MyTime");
            }
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

        public XElement SaveToXml()
        {
            var x = new XElement("results");
            foreach (var q in questions)
                x.Add(q.SaveToXml());
            return x;
        }

        void DoneAnswer()
        {

            var result = MessageBox.Show(
                "Вы уверены?",
                "Завершение теста",
                MessageBoxButton.YesNo
                );
            if (result == MessageBoxResult.Yes)
            {
                onDone();
            }
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
