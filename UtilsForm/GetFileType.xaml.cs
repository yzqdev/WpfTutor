using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// GetFileType.xaml 的交互逻辑
    /// </summary>
    public partial class GetFileType : Window
    {
     
        public GetFileType()
        {
            InitializeComponent();
            this.DataContext = FileInfos;
        }
        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private string[] _fileInfos;
        string[] FileInfos { 
            get { return _fileInfos; }
            set { _fileInfos = value;OnPropertyChanged(); } }
        public void Data_List(ListView LV, string F)  //Form或MouseEventArgs添加命名空间using System.Windows.Forms;
        {
            string enlarge = "";
            if (F.LastIndexOf(".") == F.Length - 4)
            {
                enlarge = F.Substring(F.LastIndexOf(".") + 1, 3);
            }
            //ListViewItem item = new ListViewItem(F);
            //item.SubItems.Add(enlarge);
            //LV.Items.Add(item);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;							//设置拖放操作中目标放置类型为复制
            String[] str_Drop = (String[])e.Data.GetData(DataFormats.FileDrop, true);//检索数据格式相关联的数据
            //FileInfos = str_Drop[0];
            Data_List(listView1, str_Drop[0]);
        }
    }
}
