using System;
using System.Windows;
using System.Windows.Controls;

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
                rtb.SelectionChanged += (object sender, RoutedEventArgs ee)
                => {
                    var text = rtb.Selection.Text;
                    //TODO: work with spaces
                    manager.CurrentWord = text;
                };
            }
        }

    }
}
