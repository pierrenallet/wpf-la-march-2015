using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TestSuggestion
{
    class RichTextBoxProperties
    {


        public static bool GetIsSelectedTextEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSelectedTextEnabledProperty);
        }

        public static void SetIsSelectedTextEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSelectedTextEnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsSelectedTextEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedTextEnabledProperty =
            DependencyProperty.RegisterAttached("IsSelectedTextEnabled", typeof(bool), typeof(RichTextBoxProperties), new PropertyMetadata(false, OnIsSelectedTextEnabled));
        private static void OnIsSelectedTextEnabled(object sender, DependencyPropertyChangedEventArgs args)
        {
            bool v = (bool)args.NewValue;
            if (v)
            {
                RichTextBox rtb = (RichTextBox)sender;
                rtb.SelectionChanged += Rtb_SelectionChanged;
            }
        }

        private static void Rtb_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            var position = rtb.Selection.End.GetCharacterRect(LogicalDirection.Forward);
            Debug.WriteLine(" " + position.Right + " " + position.Bottom);
            ToolTipService.SetVerticalOffset(rtb, position.Bottom);
            ToolTipService.SetHorizontalOffset(rtb, position.Right);
            rtb.SetValue(RichTextBoxProperties.SelectedTextProperty, rtb.Selection.Text);
        }



        public static string GetSelectedText(DependencyObject obj)
        {
            return (string)obj.GetValue(SelectedTextProperty);
        }

        public static void SetSelectedText(DependencyObject obj, string value)
        {
            obj.SetValue(SelectedTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for SelectedText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedTextProperty =
            DependencyProperty.RegisterAttached("SelectedText", typeof(string), typeof(RichTextBoxProperties), new PropertyMetadata(null));


    }
}
