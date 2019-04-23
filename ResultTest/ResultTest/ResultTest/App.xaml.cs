using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ResultTest
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Random Rnd = new Random((int)DateTime.Now.ToBinary());
        public static IDialogService WindowServiceOverride { get; internal set; }
        public static ITestService TestServiceOverride { get; internal set; }
    }
}
