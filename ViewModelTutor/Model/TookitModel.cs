using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
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
            DownloadTextCommand = new AsyncRelayCommand(DownloadTextAsync);
        }
        public void Show()
        {
            Name = "bbbbbbbbb";
            MessageBox.Show(Name);
        }
    }
}
