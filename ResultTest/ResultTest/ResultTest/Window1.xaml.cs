﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ResultTest
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public User Anketa { get; set; }

        public Window1()
        {
            InitializeComponent();
            Anketa = new User();
            this.DataContext = Anketa;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
