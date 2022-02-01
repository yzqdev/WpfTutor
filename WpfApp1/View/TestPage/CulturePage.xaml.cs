using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WpfApp1.View.TestPage
{
    /// <summary>
    /// CulturePage.xaml 的交互逻辑
    /// </summary>
    public partial class CulturePage : Window
    {
        public CulturePage()
        {
            InitializeComponent();
        }
 public static string CurrentCulture { get; set; }

        public static CultureInfo CurrentCultureInfo { get; set; }
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            //https://docs.microsoft.com/zh-cn/openspecs/windows_protocols/ms-lcid/a9eac961-e77d-41a6-90a5-ce1a8b0cdb9c
            string culture = "zh-CN";
            CurrentCultureInfo ??= CultureInfo.CurrentUICulture;
           cultureLabel.Content =CultureInfo.GetCultureInfo(culture).Parent.Name;
            //cultureLabel.Content = CurrentCultureInfo.Name;
        }
    }
}
