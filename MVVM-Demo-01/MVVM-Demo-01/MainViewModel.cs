using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Demo_01
{
    class MainViewModel : ViewModel
    {
        public LoginViewModel LoginVM { get;  } = new LoginViewModel();
    }
}
