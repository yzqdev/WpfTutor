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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
           
            
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            MessageBox.Show("deacte");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           CloseWindow closeWindow=new CloseWindow();
            closeWindow.Show();
        }

        private void styleWindow_Click(object sender, RoutedEventArgs e)
        {
            StyleWindow styleWindow=new StyleWindow();
            styleWindow.Show();
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow closeWindow = new CloseWindow();
            closeWindow.Show();
        }

        private void newWindow_Click(object sender, RoutedEventArgs e)
        {
            NewWindow newWindow=new NewWindow();
            newWindow.Show();
        }
    }
}
