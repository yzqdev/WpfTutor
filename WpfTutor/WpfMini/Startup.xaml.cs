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
using WpfTutor.View;
using WpfTutor.View.Layouts;

namespace WpfTutor
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

        private void ButtonPage_Click(object sender, RoutedEventArgs e)
        {
            ButtonPage buttonPage = new ButtonPage();
            buttonPage.Show();
        }

        private void BorderPage_Click(object sender, RoutedEventArgs e)
        {
            BorderPage borderPage = new BorderPage();
            borderPage.Show();
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFilePage saveFilePage = new SaveFilePage();
            saveFilePage.Show();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFilePage openFilePage = new OpenFilePage();
            openFilePage.Show();
        }

        private void MenuPage_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage=new MenuPage();
            menuPage.Show();
        }

        private void ImagePage_Click(object sender, RoutedEventArgs e)
        {
            ImagePage imagePage = new ImagePage();
            imagePage.Show();
        }

        private void ComboPage_Click(object sender, RoutedEventArgs e)
        {
            ComboPage comboPage=new ComboPage();
            comboPage.Show();
        }
    }
}
