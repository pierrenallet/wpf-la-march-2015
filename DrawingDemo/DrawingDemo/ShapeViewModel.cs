using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingDemo
{

    class ShapeViewModel : ViewModel
    {
        private string _fill;

        public string Fill
        {
            get { return _fill; }
            set { _fill = value; NotifyPropertyChanged(); }
        }

        private string _data;

        public string Data
        {
            get { return _data; }
            set { _data = value;NotifyPropertyChanged(); }
        }

        private string _stroke;

        public string Stroke
        {
            get { return _stroke; }
            set { _stroke = value; NotifyPropertyChanged();  }
        }
        private string _strokeThickness;

        public string StrokeThickness
        {
            get { return _strokeThickness; }
            set { _strokeThickness = value; NotifyPropertyChanged(); }
        }

        private string _strokeDashArray;

        public string StrokeDashArray
        {
            get { return _strokeDashArray; }
            set { _strokeDashArray = value; NotifyPropertyChanged(); }
        }
    }
}
