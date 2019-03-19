using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace TestAlg
{
   
    public partial class MainWindow : Window
    {
        TestViewModel model;
        User regUser;

        private void OnDone()
        {
            var xTestResult = model.SaveToXml();
            var xUser = regUser.SaveToXml();
            var x = new XElement("Test");
            x.Add( xTestResult);
            x.Add( xUser);
            x.Save("Done.xml");
            MessageBox.Show("Вы завершили тест!");
            Application.Current.Shutdown();

        }

        public MainWindow()
        {
            InitializeComponent();
            XElement xml = XElement.Load(@"D:\kurs\TestAlg\bin\Debug\data.xml");
            var questionBank = QuestionBlank.LoadFromXml(xml);
            var questions = TestGeneretor.Generate(questionBank, OnDone);
            model = questions;
            this.DataContext = model;
        }

        protected override void OnInitialized(EventArgs e)
        {
            var regForm = new Window1();
            regForm.ShowDialog();
            regUser = regForm.Anketa;
            base.OnInitialized(e);
        }


    }
}
