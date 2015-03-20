using System.Windows;
using System.Windows.Controls;

namespace Intellisense
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReplaceSelectedText(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            RichTextBox rtb = (RichTextBox) sender;
            rtb.Selection.Text = (string)e.Parameter;
        }
    }
}
