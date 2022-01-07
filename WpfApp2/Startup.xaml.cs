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
using System.Windows.Shapes;
using WpfApp2.View;
using WpfApp2.View.Layouts;

namespace WpfApp2
{
    /// <summary>
    /// Startup.xaml 的交互逻辑
    /// </summary>
    public partial class Startup : Window
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void mainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void tabPage_Click(object sender, RoutedEventArgs e)
        {
            TabPage tabPage = new TabPage();
            tabPage.Show();
        }

        private void TextBoxPage_Click(object sender, RoutedEventArgs e)
        {
            TextBoxPage textBoxPage = new();
            textBoxPage.Show();
        }

        private void layout_Click(object sender, RoutedEventArgs e)
        {
            Layouts layouts = new Layouts();
            layouts.Show();
        }

        private void StylePage_Click(object sender, RoutedEventArgs e)
        {
            StylePage style = new();
            style.Show();
        }
    }
}
