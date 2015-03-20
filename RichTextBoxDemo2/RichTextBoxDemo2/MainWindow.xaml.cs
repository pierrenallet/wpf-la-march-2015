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

namespace RichTextBoxDemo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = typeof(Brushes).GetProperties().Select(p => p.GetValue(null));
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RichTextBox rtb = (RichTextBox) e.Source;
            rtb.Selection.ApplyPropertyValue(RichTextBox.ForegroundProperty, e.Parameter);
        }
    }
}
