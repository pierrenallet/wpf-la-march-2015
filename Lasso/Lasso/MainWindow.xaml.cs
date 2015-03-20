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

namespace Lasso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }
        LassoViewModel vm = new LassoViewModel();

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas c = (Canvas)sender;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                vm.AddPoint(e.GetPosition(c));

            }
            foreach(Rectangle rect in targetCanvas.Children)
            {
                rect.Fill = Brushes.Black;
            }
            var geometry = this.path.RenderedGeometry;
            VisualTreeHelper.HitTest(this.targetCanvas,
                null, new HitTestResultCallback(OnTestResult),
                new GeometryHitTestParameters(geometry));
        }

        private HitTestResultBehavior OnTestResult(HitTestResult result)
        {
            Rectangle r = (Rectangle)result.VisualHit;
            r.Fill = Brushes.Blue;
            return HitTestResultBehavior.Continue;
        }

    }
}
