using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModelTutor.ViewModel;
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    //下面这个不用写名字
    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

