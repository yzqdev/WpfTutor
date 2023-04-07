using System;
using System.Windows.Input;

namespace WpfLayout.ViewModel;

public class Command : ICommand
{
    private readonly Action<object> command;
    public event EventHandler CanExecuteChanged;

    public Command(Action<object> command)
    {
        this.command = command;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        command(parameter);
    }
}