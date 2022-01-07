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
using ViewModelTutor.View;

namespace ViewModelTutor
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

        private void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow=new MainWindow();
            mainWindow.Show();
        }

        private void BindConv_Click(object sender, RoutedEventArgs e)
        {
            BindConversion bindConversion = new BindConversion();
            bindConversion.Show();
        }

        private void Simple_Click(object sender, RoutedEventArgs e)
        {
            SimpleBind simpleBind=new SimpleBind();
            simpleBind.Show();
        }
    }
}
