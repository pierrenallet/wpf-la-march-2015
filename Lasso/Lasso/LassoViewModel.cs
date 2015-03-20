using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lasso
{
    class LassoViewModel : INotifyPropertyChanged
    {
        List<Point> Points { get; } = new List<Point>();

        public event PropertyChangedEventHandler PropertyChanged;

        internal void AddPoint(Point point)
        {
            Points.Add(point);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public string PathData
        {
            get
            {
                if (!Points.Any())
                    return null;
                return "M" + this.Points.First().X + " " + Points.First().Y +
                    string.Join(" ", this.Points.Select(p => "L" + p.X + " " + p.Y)) + " ";
            }
        }
    }
}
