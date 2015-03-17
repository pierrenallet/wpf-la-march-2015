using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Clock
{
    class RadialPanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            if (Children.Count == 0)
                return new Size(0, 0);
            foreach(FrameworkElement element in Children)
            {
                element.Measure(availableSize);
            }
            return new Size(
                Children.OfType<FrameworkElement>().Max(e => e.DesiredSize.Width),
                Children.OfType<FrameworkElement>().Max(e => e.DesiredSize.Height)
                );
        }
        protected override Size ArrangeOverride(Size finalSize)
        {

            var center = new Point(finalSize.Width / 2, finalSize.Height / 2);
            var radius = Math.Min(center.X, center.Y);
            foreach(FrameworkElement element in Children)
            {
                var angle = GetAngle(element);
                angle = + angle * Math.PI / 6 - Math.PI / 2;
                var n = Math.Sqrt(element.DesiredSize.Width * element.DesiredSize.Height);
                var elementRadius = radius - n;

                Point position = new Point(center.X - n/2 + elementRadius * Math.Cos(angle), center.Y + elementRadius * Math.Sin(angle) - n/2);

                var rect = new Rect(position, element.DesiredSize);
                element.Arrange(rect);

            }
            return finalSize;
        }



        public static double GetAngle(DependencyObject obj)
        {
            return (double)obj.GetValue(AngleProperty);
        }

        public static void SetAngle(DependencyObject obj, double value)
        {
            obj.SetValue(AngleProperty, value);
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.RegisterAttached("Angle", typeof(double), typeof(RadialPanel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsParentMeasure));



    }
}
