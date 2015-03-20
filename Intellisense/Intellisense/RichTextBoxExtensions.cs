using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Intellisense
{
    static class RichTextBoxExtensions
    {
        static RichTextBoxExtensions()
        {
            var binding = new CommandBinding()
            {
                Command = ReplaceSelectedText,

            };
            binding.Executed += (sender, e)
            =>
            {
                RichTextBox rtb = (RichTextBox)sender;
                rtb.Selection.Text = (string)e.Parameter;
            };
            CommandManager.RegisterClassCommandBinding(typeof(RichTextBox), binding);

        }

        public static RoutedCommand ReplaceSelectedText
        { get; }    
        = new RoutedCommand("replaceSelectedText", typeof(RichTextBoxExtensions));

        public static Rect GetCaretPosition(DependencyObject obj)
        {
            return (Rect)obj.GetValue(CaretPositionProperty);
        }

        public static void SetCaretPosition(DependencyObject obj, Rect value)
        {
            obj.SetValue(CaretPositionProperty, value);
        }

        // Using a DependencyProperty as the backing store for CaretPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaretPositionProperty =
            DependencyProperty.RegisterAttached("CaretPosition", typeof(Rect), typeof(RichTextBoxExtensions), new PropertyMetadata(new Rect()));




        public static bool GetCaretPositionEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(CaretPositionEnabledProperty);
        }

        public static void SetCaretPositionEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(CaretPositionEnabledProperty, value);
        }

        // Using a DependencyProperty as the backing store for CaretPositionEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CaretPositionEnabledProperty =
            DependencyProperty.RegisterAttached("CaretPositionEnabled", typeof(bool), typeof(RichTextBoxExtensions), new PropertyMetadata(false, new PropertyChangedCallback(OnEnabledChanged)));

        private static void OnEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichTextBox rtb = (RichTextBox)d;
            if (e.NewValue.Equals(true))
            {
                rtb.SelectionChanged += (_, __) =>
                {
                    var rect = rtb.Selection.End.GetCharacterRect(System.Windows.Documents.LogicalDirection.Forward);
                    rect.Offset(0, rect.Height);
                    SetCaretPosition(rtb, rect);
                };
            }
        }
    }
}
