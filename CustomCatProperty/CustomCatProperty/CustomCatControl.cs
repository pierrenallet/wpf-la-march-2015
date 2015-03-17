using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace CustomCatProperty
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomCatProperty"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomCatProperty;assembly=CustomCatProperty"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomCatControl/>
    ///
    /// </summary>
    public class CustomCatControl : Control
    {
        static CustomCatControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomCatControl), new FrameworkPropertyMetadata(typeof(CustomCatControl)));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            drawingContext.DrawText(
                new FormattedText("Hello Cat " + CatName, CultureInfo.CurrentCulture, 
                    FlowDirection.LeftToRight,
                    new Typeface("Arial"), 24.0, Brushes.Green),new Point(0,0));
        }





        public string CatName
        {
            get { return (string)GetValue(CatNameProperty); }
            set { SetValue(CatNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CatName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CatNameProperty =
            DependencyProperty.Register("CatName", typeof(string), typeof(CustomCatControl), 
            new FrameworkPropertyMetadata("Kitty",FrameworkPropertyMetadataOptions.AffectsRender));

        

    }
}
