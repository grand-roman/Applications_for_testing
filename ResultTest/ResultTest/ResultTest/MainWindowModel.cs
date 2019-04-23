using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace ResultTest
{
    class MyCommand : ICommand
    {
        private MainWindowModel owner;

        public Action Operation { get; set; }

        public MyCommand(MainWindowModel owner)
        {
            this.owner = owner;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var service = ServiceResolver.GetDialogService();
            Operation();
        }
    }

    class MainWindowModel : INotifyPropertyChanged
    {
        private MyCommand takeStudent;
        private MyCommand takeBank;
        private MyCommand takeSave;

        private MyCommand takeCheckStudent;
        private MyCommand takeKeyStudent;
        private MyCommand takeSaveScore;

        public string Student { get; set; }
        public string BankQ { get; set; }
        public string SaveBlank { get; set; }

        public string Score { get; set; }
        public string CheckStudent { get; set; }
        public string KeyStudent { get; set; }

        public MainWindowModel()
        {
            takeStudent = new MyCommand(this);
            takeStudent.Operation = TakeStudent;
            takeBank = new MyCommand(this);
            takeBank.Operation = TakeBank;
            takeSave = new MyCommand(this);
            takeSave.Operation = TakeSave;

            takeCheckStudent = new MyCommand(this);
            takeCheckStudent.Operation = TakeCheckStudent;
            takeKeyStudent = new MyCommand(this);
            takeKeyStudent.Operation = TakeKeyStudent;
            takeSaveScore = new MyCommand(this);
            takeSaveScore.Operation = TakeSaveScore;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void TakeStudent()
        {
            var service = ServiceResolver.GetDialogService();
            var f = service.ShowOpenFileDialog();
            Student = f;
            OnPropertyChanged("Student");
        }

        void TakeBank()
        {
            var service = ServiceResolver.GetDialogService();
            var f = service.ShowOpenFileDialog();
            BankQ = f;
            OnPropertyChanged("BankQ");
        }

        void TakeSave()
        {
            var service = ServiceResolver.GetDialogService();
            var folder = service.PickFolder();
            SaveBlank = folder;
            OnPropertyChanged("SaveBlank");
            var savService = ServiceResolver.GetTestService();
            savService.Generate(Student, BankQ, SaveBlank);
        }

        void TakeSaveScore()
        {
            var service = ServiceResolver.GetDialogService();
            var folder = service.PickFolder();
            Score = folder;
            OnPropertyChanged("Score");
        }

        void TakeCheckStudent()
        {
            var service = ServiceResolver.GetDialogService();
            var f = service.PickFolder();
            CheckStudent = f;
            OnPropertyChanged("CheckStudent");
        }

        void TakeKeyStudent()
        {
            var service = ServiceResolver.GetDialogService();
            var f = service.PickFolder();
            CheckStudent = f;
            OnPropertyChanged("KeyStudent");

        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public ICommand SelectStudent { get { return takeStudent; } }
        public ICommand SelectBank { get { return takeBank; } }
        public ICommand SaveAllBank { get { return takeSave; } }

        public ICommand SelectCheckStudent { get { return takeCheckStudent; } }
        public ICommand SelectKeyStudent { get { return takeKeyStudent; } }
        public ICommand SaveScore { get { return takeSaveScore; } }

    }
}
