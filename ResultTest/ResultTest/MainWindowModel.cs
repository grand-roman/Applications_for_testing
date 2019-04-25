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
        private MyCommand takeClear;
        private MyCommand takeSaveScore;

        public string Student { get; set; }
        public string BankQ { get; set; }
        public string SaveBlank { get; set; }

        public string Score { get; set; }

        public ListModel ListModels { get; set; }

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
            takeClear = new MyCommand(this);
            takeClear.Operation = TakeClear;
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
            //var service = ServiceResolver.GetDialogService();
            //var folder = service.PickFolder();
            //Score = folder;
            //OnPropertyChanged("Score");
        }

        void TakeCheckStudent()
        {
            var service = ServiceResolver.GetDialogService();
            var f = service.Joins();
            ListModels = ListModel.Zzz(f);

            OnPropertyChanged("ListModel");

        }

        void TakeClear()
        {
            ListModels = null;
            OnPropertyChanged("ListModel");
            OnPropertyChanged("CheckStudent");
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
        public ICommand SelectClearStudent { get { return takeClear; } }
        public ICommand SaveScore { get { return takeSaveScore; } }
    }

    class ListModel : List<ListItemModel>
    {
        public static ListModel Zzz(string[] f)
        {
            List<XElement> res = new List<XElement>();
            foreach (var item in f)
            {
                res.Add(XElement.Load(item));
            }
            Dictionary<String, Tuple<XElement, XElement>> TestKey = new Dictionary<string, Tuple<XElement, XElement>>();
            foreach (var x in res)
            {
                var rootName = x.Name.LocalName;
                var guid = (string)x.Element("Guid");
                if (TestKey.ContainsKey(guid))
                {
                    var k = TestKey[guid];
                    if (k.Item1 != null && k.Item1.Name.LocalName == "Test")
                        TestKey[guid] = new Tuple<XElement, XElement>(k.Item1, x);
                    else
                        TestKey[guid] = new Tuple<XElement, XElement>(x, k.Item2);
                }
                else
                {
                    if (rootName == "Test")
                        TestKey.Add(guid, new Tuple<XElement, XElement>(x, null));
                    else
                        TestKey.Add(guid, new Tuple<XElement, XElement>(null, x));
                }
            }
            var ListModel = new ListModel();
            foreach (var resof in TestKey.Values)
            {
                var key = KeyStudent.LoadFromXml(resof.Item2);
                var test = ResStudent.LoadFromXml(resof.Item1);
                if (test == null)
                    ListModel.Add(new ListItemModel()
                    {
                        KeyStudent = key.User
                    });
                if (key == null)
                    ListModel.Add(new ListItemModel()
                    {
                        CheckStudent = test.User
                    });
                else
                    ListModel.Add(new ListItemModel()
                    {
                        CheckStudent = test.User,
                        KeyStudent = key.User,
                        Score = null
                    });
            }

            return ListModel;
            
        }

    }

    class ListItemModel
    {
        public string Score { get; set; }

        public string CheckStudent { get; set; }
        public string KeyStudent { get; set; }

        static string TakeScore(ResStudent test , KeyStudent key)
        {
            ///ТУТ БУДЕТ ОЦЕНКА
            return "-1";
        }

    }
}
