using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TextEditor
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

        private void CommandBinding _Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ((Button)sender).Content = Clipboard.GetText();
        }
    }
}
