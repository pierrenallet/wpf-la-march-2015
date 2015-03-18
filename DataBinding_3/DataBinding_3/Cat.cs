using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding_3
{
    class Cat : INotifyPropertyChanged
    {
        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName]string propertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Color { get; set; }
        public string Name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
