// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Windows;
using ViewModelTutor.View;

namespace ViewModelTutor.ViewModel
{
    // This class implements INotifyPropertyChanged
    // to support one-way and two-way bindings
    // (such that the UI element updates when the source
    // has been changed dynamically)
    public class Person : ViewModelBase
    {
        private string _name;
        public MyCommand myCommand { get; set; }

        public void Show()
        {
            Name = "Ů";
            MessageBox.Show(Name);
        }
        public Person()
        {
            Name = "��";
            myCommand = new MyCommand(Show);
        }

        public Person(string value)
        {
            _name = value;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

    }
}