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
    /// MousePosition.xaml 的交互逻辑
    /// </summary>
    public partial class MousePosition : Window
    {
        public MousePosition()
        {
            InitializeComponent();
        }
        System.Windows.Threading.DispatcherTimer dispatcherTimer ;
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


           dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

            // Tick 超过计时器间隔时发生。
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            // Interval 获取或设置计时器刻度之间的时间段
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(10);

            dispatcherTimer.Start();


     
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)//计时执行的程序
        {
            mousePos.Content = "鼠标当前坐标[X:" + Mouse.GetPosition(this).X + "  Y:" + Mouse.GetPosition(this).Y + "]";
            Point ptLeftUp = new Point(0, 0);
            Point ptRightDown = new Point(this.ActualWidth, this.ActualHeight);
            windowPos.Content = "窗口坐标[X:" + this.PointToScreen(ptLeftUp) + " Y:" + this.PointToScreen(ptRightDown) + "]";
            windowsSize.Content = "窗口大小[宽:" + this.ActualWidth + " 长:" + this.ActualHeight + "]";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;							//设置拖放操作中目标放置类型为复制
            String[] str_Drop = (String[])e.Data.GetData(DataFormats.FileDrop, true);//检索数据格式相关联的数据
             
            fileLocation.Text= str_Drop[0];
             
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(fileLocation.Text);
            MessageBox.Show("已复制", "提示");
        }
    }
}
