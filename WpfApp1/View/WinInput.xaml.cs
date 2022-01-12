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
using WindowsInput.Events;

namespace WpfApp1.View
{
    /// <summary>
    /// WinInput.xaml 的交互逻辑
    /// </summary>
    public partial class WinInput : Window
    {
        public WinInput()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            WindowsInput.Simulate.Events()
        //Hold Windows Key+R
        .ClickChord(KeyCode.Control,KeyCode.Alt, KeyCode.Q).Wait(1000)
         

        //Do it!
        .Invoke();
        }
    }
}
