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
using WpfTest.View.Styles;

namespace WpfTest.View
{
    /// <summary>
    /// StylePage.xaml 的交互逻辑
    /// </summary>
    public partial class StylePage : Window
    {
        public StylePage()
        {
            InitializeComponent();
        }
        private void BasicStyle_Click(object sender, RoutedEventArgs e)
        {
            BasicStyle bas = new BasicStyle();
            bas.Show();
        }

        private void TriggerStyle_Click(object sender, RoutedEventArgs e)
        {
            TriggerStyle triggerStyle   =new TriggerStyle(); 
            triggerStyle.Show();
        }
    }
}
