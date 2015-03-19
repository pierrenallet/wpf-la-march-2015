using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Demo_01
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propName));
        }
    }
}
