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

namespace DatabindingCars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new List<Brand>
            {
                new Brand { Name = "Toyota",
                            Models = new List<Model> {
                                new Model {  Name = "Prius", NumberOfDoors = 4 },
                                new Model { Name = "Camry", NumberOfDoors = 4 } } },
                new Brand { Name = "Nissan",
                            Models = new List<Model> {
                                new Model { Name = "300Z", NumberOfDoors = 2 },
                                new Model { Name = "Maxima", NumberOfDoors = 4 } } } };
        }
    }
}

