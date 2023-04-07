using System.Windows.Controls;
 
using WpfTest.ViewModels;
using System.Text.Json;
namespace WpfTest.Views;

public partial class MainPage : Page {
    public MainPage(MainViewModel viewModel) {
        InitializeComponent();
        DataContext = viewModel;
    }

    private async  void getSign( ) {
       
    }

    private async void hoyolab_Click(object sender, System.Windows.RoutedEventArgs e) {
       getSign();
    }
}
