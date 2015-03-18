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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal List<Cat> myCats = new List<Cat>()
        {
            new Cat { Age = 1, Color = "Black", Name = "Felix" },
            new Cat { Age = 15, Color = "Gray", Name = "Spunky" }
        };

        public MainWindow()
        {
            InitializeComponent();

            DataContext = myCats;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            Cat c = (Cat)element.DataContext;
            c.Age++;
        }
    }
}
