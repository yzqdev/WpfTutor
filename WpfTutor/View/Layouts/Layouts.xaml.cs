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

namespace WpfTutor.View.Layouts
{
    /// <summary>
    /// Layouts.xaml 的交互逻辑
    /// </summary>
    public partial class Layouts : Window
    {
        public Layouts()
        {
            InitializeComponent();
        }

        private void stackPanel_Click(object sender, RoutedEventArgs e)
        {
            StackPanelPage stackPanelPage = new StackPanelPage();
            stackPanelPage.Show();
        }

        private void dockPanel_Click(object sender, RoutedEventArgs e)
        {
            DockPanelPage    dockPanelPage = new DockPanelPage();
            dockPanelPage.Show();
        }

        private void wrapPanel_Click(object sender, RoutedEventArgs e)
        {
            WrapPanelPage wrapPanelPage = new();
            wrapPanelPage.Show();
        }

        private void uniFormPanel_Click(object sender, RoutedEventArgs e)
        {
            UniformPage uniFormPanel = new UniformPage();
            uniFormPanel.Show();
        }

        private void allPanel_Click(object sender, RoutedEventArgs e)
        {
            AllPanelPage allPanelPage = new AllPanelPage();
            allPanelPage.Show();
        }
    }
}
