using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace Intellisense
{
    class IntellisenseService
    {

        public static IntellisenseManager GetManager(DependencyObject obj)
        {
            return (IntellisenseManager)obj.GetValue(ManagerProperty);
        }

        public static void SetManager(DependencyObject obj, IntellisenseManager value)
        {
            obj.SetValue(ManagerProperty, value);
        }

        // Using a DependencyProperty as the backing store for Manager.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ManagerProperty =
            DependencyProperty.RegisterAttached("Manager", typeof(IntellisenseManager), typeof(IntellisenseService), new PropertyMetadata(
                null, new PropertyChangedCallback(OnManagerChanged)));

        private static void OnManagerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //TODO if e.OldValue != null, remove event handler;
            if (e.NewValue != null)
            {
                IntellisenseManager manager = (IntellisenseManager)e.NewValue;
                RichTextBox rtb = (RichTextBox)d;
                RichTextBoxExtensions.SetCaretPositionEnabled(rtb, true);
                rtb.SelectionChanged += (object sender, RoutedEventArgs ee)
                => {
                    var text = rtb.Selection.Text;
                    //TODO: work with spaces
                    manager.CurrentWord = text;
                };
                Popup popup = new Popup();
                popup.Placement = PlacementMode.RelativePoint;
                popup.PlacementTarget = rtb;
                popup.Child = new ContentPresenter { Content = manager };
                popup.IsOpen = true;
                popup.SetBinding(Popup.PlacementRectangleProperty, new Binding() { Source = rtb, Path = new PropertyPath(RichTextBoxExtensions.CaretPositionProperty)});
                FocusManager.SetIsFocusScope(popup, true);


            }
        }

    }
}
