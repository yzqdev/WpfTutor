using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModelTutor
{
    /// <summary> 
    /// MainWindow.xaml 的交互逻辑 
    /// </summary> 
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> stuList;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Student() { Name = "111", Id = 1 };
            Task.Run(async () =>  //开启异步线程task 
            {
                await Task.Delay(3000); //延时3秒 
                Dispatcher.Invoke((Action)delegate //线程中主界面显示需要用委托，不然这次赋值，在界面不更新 
                {
                    this.DataContext = new Student() { Name = "222", Id = 2 };
                });
            });
            this.DataContext = new Student() { Name = "333", Id = 3 };
        }

        private void BtnCtrl1_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student() { Id = 4, Name = "Jon", Age = 29 }; //实例化一个Student类 并给类成员赋值 
            this.DataContext = stu;//将实例化得对象传给DataContext 
        }
        private void BtnCtrl2_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Student> stuList = new ObservableCollection<Student>() //具有通知属性的list 
            {
             new Student() { Id=5, Name="Tim", Age=29 },
             new Student() { Id=6, Name="Tom", Age=28 },
             };
            this.listBox1.ItemsSource = stuList;

            this.listBox2.ItemsSource = stuList;
            this.listBox2.DisplayMemberPath = "Name";
            this.DataContext = stuList;
        }
    }
    public class Student : INotifyPropertyChanged  //创建一个继承自INotifyPropertyChanged的类Student 
    {

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name))); //给Name绑定属性变更通知事件 
                }
            }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));//给Id绑定属性变更通知事件 
                }
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Age"));//给Age绑定属性变更通知事件 
                }
            }
        }

        public int ID { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}