using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Intellisense
{
    // TODO: define intellisenseManager interface
    class IntellisenseManager : INotifyPropertyChanged
    {
        private string _currentWord;

        public bool IsOpen
        {
            get
            {
                return this.Suggestions.Any();
            }
        }
        public string CurrentWord
        {
            get { return _currentWord; }
            set { _currentWord = value;
                this.NotifyPropertyChanged(null);
            }
        }

        private void NotifyPropertyChanged([CallerMemberName]string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<string> Items
        { get; set; }
        = new List<string>
         {
             "Apple",
             "Orange",
             "Plum",
             "Banana",
             "PineApple",
         };
        public IEnumerable<string> Suggestions
        {
            get
            {
                if (string.IsNullOrEmpty(CurrentWord))
                    return Enumerable.Empty<string>();
                return Items.Where(s => s.ToLower().Contains(CurrentWord.ToLower()
                    ));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
