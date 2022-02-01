using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModelTutor.View;

namespace ViewModelTutor.Model
{
    public class TookitModel:ObservableObject
    {

        public IAsyncRelayCommand DownloadTextCommand { get; }

        private async Task<string> DownloadTextAsync()
        {
            await Task.Delay(1000); // Simulate a web request
            Name = "1秒后";
            return "Hello world!";
        }
        public  RelayCommand ClickCommand { get;  }
        public  RelayCommand openCommand { get;  }
        private string _name;
        public string Name { 
            get { return _name; } 
            set {
                SetProperty(ref _name, value);
            }
        }
        public TookitModel()
        {
            Name = "初始名字";
            ClickCommand = new  RelayCommand(Show);
            openCommand=new RelayCommand(open);
            DownloadTextCommand = new AsyncRelayCommand(DownloadTextAsync);
        }
        public void Show()
        {
            Name = "bbbbbbbbb";
            MessageBox.Show(Name);
        }
        public void open()
        {
            var dialog = new VistaFolderBrowserDialog();
            dialog.Description = "Please select a folder.";
            dialog.UseDescriptionForTitle = true; // This applies to the Vista style dialog only, not the old dialog.

            if (!VistaFolderBrowserDialog.IsVistaFolderDialogSupported)
            {
                MessageBox.Show("Because you are not using Windows Vista or later, the regular folder browser dialog will be used. Please use Windows Vista to see the new dialog.", "Sample folder browser dialog");
            }

            if ((bool)dialog.ShowDialog())
            {

                Name = dialog.SelectedPath;
                string a = "aaa";
                MessageBox.Show($"The selected folder was:{Environment.NewLine}{Name}", "Sample folder browser dialog");
            }
        }
    }
}
