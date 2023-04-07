using System.Windows.Controls;

using WpfTest.ViewModels;

namespace WpfTest.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
