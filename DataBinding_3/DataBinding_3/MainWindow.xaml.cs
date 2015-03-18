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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Cat MyCat = new Cat { Age = 1, Color = "Black", Name = "Felix" };
        public MainWindow()
        {
            InitializeComponent();

            DataContext = MyCat;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyCat.Name = "Spunky";
            MyCat.Age += 1;  
               
        }
    }
}
