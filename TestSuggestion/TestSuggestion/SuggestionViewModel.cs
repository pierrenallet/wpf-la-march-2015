using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSuggestion
{
    class SuggestionViewModel : ViewModel
    {
        private string _text = string.Empty;

        public string Text
        {
            get { return _text; }
            set { _text = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(Suggestions));
            }
        }
        static string[] allSuggestions = new string[] { "Apple", "Orange", "Pear" };

        public IEnumerable<string> Suggestions
        {
            get
            {
                if (string.IsNullOrEmpty(this.Text))
                    return Enumerable.Empty<string>();
                return allSuggestions.Where(s => s.ToLower().Contains((this.Text??string.Empty).ToLower()));

            }
        }
    }
}
