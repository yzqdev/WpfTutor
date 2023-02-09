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

namespace WpfTutor.View
{
    /// <summary>
    /// ComboPage.xaml 的交互逻辑
    /// </summary>
    public partial class ComboPage : Window
    {
        public ComboPage()
        {
            InitializeComponent();
        }

        private void box1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(e.AddedItems);
             result.Content = box1.SelectedItem;
        }

        private void addCombo_Click(object sender, RoutedEventArgs e)
        {
            box1.Items.Add("bbb");
        }
    }
}
