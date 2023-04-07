﻿using System;
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
using ViewModelTutor.Model;

namespace ViewModelTutor.View
{
    /// <summary>
    /// SimpleBind.xaml 的交互逻辑
    /// </summary>
    public partial class SimpleBind : Window
    {
        public SimpleBind()
        {
            InitializeComponent();
            DataContext = new Person() {  Name = "hhhhh" };
        }

        
    }
}
