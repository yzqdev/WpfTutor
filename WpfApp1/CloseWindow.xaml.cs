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

namespace WpfApp1
{
    /// <summary>
    /// CloseWindow.xaml 的交互逻辑
    /// </summary>
    public partial class CloseWindow : Window
    {
        public CloseWindow()
        {
            InitializeComponent();
        }
        private void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Close the current window
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Error;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            MessageBox.Show(result.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "hhh";
            dialog.DefaultExt = "txt";
            dialog.Filter = "视频文件|*.mp4";
            bool?res=dialog.ShowDialog();
            if ((bool)res)
            {
                MessageBox.Show("hhh");
            }
        }

         
    }
}
