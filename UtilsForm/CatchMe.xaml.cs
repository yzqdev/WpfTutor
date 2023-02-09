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

namespace UtilsForm
{
    /// <summary>
    /// CatchMe.xaml 的交互逻辑
    /// </summary>
    public partial class CatchMe : Window
    {
        public CatchMe()
        {
            InitializeComponent();
        }

        private void cantButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("你简直是个住!", "我是猪");
        }

        private void cantButton_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void cantButton_MouseEnter(object sender, MouseEventArgs e)
        {
             
            int x = (int)(this.ActualWidth - cantButton.Width);
            int y = (int)(this.ActualHeight - cantButton.Height);
            Random random = new Random();
            cantButton.Margin= new Thickness(random.Next(0,  x + 1 ), random.Next(0,  y + 1 ),0,0);
        }
    }
}
