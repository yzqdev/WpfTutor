using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModelTutor.View
{
   public class MyCommand : ICommand
    {
        Action exeAction;
        public event EventHandler? CanExecuteChanged;
        public MyCommand(Action action)
        {
            exeAction = action;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
           exeAction();
        }
    }
}
