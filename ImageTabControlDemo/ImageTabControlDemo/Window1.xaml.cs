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

namespace ImageTabControlDemo
{
    class Flower
    {
        public Flower(string name, string imageName)
        {
            this.Name = name;
            this.ImageName = imageName;
        }

        public string ImageName { get; private set; }
        public string Name { get; private set; }
    }
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()

        {
            TabControl tc;
            InitializeComponent();
            DataContext = new List<Flower>
            {
                new Flower ("red", "red.jpg"),
                new Flower ("blue", "blue.jpg"),
                new Flower ("orange", "orange.jpg"),
            };
        }
    }
}
