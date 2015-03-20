using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RichTextBoxDemo2
{
    static class TextBoxCommands
    {
        static RoutedCommand _setForeground = new RoutedCommand("setForeground", typeof (TextBoxCommands));
        public static RoutedCommand SetForeground { get
            {
                return _setForeground;
            }
        }
    }
}
