using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ResultTest
{
    public interface IDialogService
    {
        string ShowOpenFileDialog();
        string PickFolder();
    }

    public interface ITestService
    {
        void Generate(string studentPath, string bankPath, string outputFolder);
        //void ResultScore(string resPath);
    }

    class InteractiveWindowService : IDialogService
    {
        public string ShowOpenFileDialog()
        {
            var d = new OpenFileDialog();

            var z = d.ShowDialog();
            if (z ?? false)
                return d.FileName;
            return null;
        }

        public string PickFolder()
        {
            var d = new System.Windows.Forms.FolderBrowserDialog();
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return d.SelectedPath;
            }
            return null;

        }
    }
}
