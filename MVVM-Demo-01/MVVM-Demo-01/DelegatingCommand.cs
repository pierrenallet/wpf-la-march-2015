using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Demo_01
{
    class DelegatingCommand : ICommand
    {

        public DelegatingCommand(Action action) : this(_ => action?.Invoke())
        {
        }

        Action<object> _action;
        public DelegatingCommand(Action<object> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

    }
}
