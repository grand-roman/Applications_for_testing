using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAlg
{
    class Probe : INotifyPropertyChanged
    {

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
                OnPropertyChanged("Andswer1");
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
                OnPropertyChanged("Andswer2");
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
                OnPropertyChanged("Andswer3");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    
}
