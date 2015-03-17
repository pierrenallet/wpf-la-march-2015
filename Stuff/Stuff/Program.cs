using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stuff
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application myApp = new Application();
            Window w = new Window()
            {
                Title = "Nice Cats"
            };

            var b = new Button()
                {
                    Content = new Ellipse
                    {
                        Fill = Brushes.Tomato,
                        Height = 100,
                        Width = 100
                    },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            b.Click += (_, __) => b.Background = Brushes.Azure;

            w.Content = b;
            myApp.Run(w);
        }

       
    }
}
