using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DatabindingColors
{
    class BrushFinder : INotifyPropertyChanged
    {
        private string text = string.Empty;

        public string Text
        {
            get { return text; }
            set { text = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Brushes")); }
        }

        public IEnumerable<NameBrush> Brushes
        {
            get
            {
                return typeof(Brushes).GetProperties()
                    .Where(p => p.Name.Contains(Text))
                    .Select(p => new NameBrush
                    {
                        Name = p.Name,
                        Brush = (Brush)p.GetValue(null)
                    });

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
