using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Demo_01
{
   
    class LoginViewModel : ViewModel
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand Login
        {
            get
            {
                //return new DelegatingCommand(
                //   s => MessageBox.Show("Hello!!!!"));
                return new DelegatingCommand(OnLogin);
            }
        }

        void OnLogin()
        {
            //check real login
            if (UserName == Password)
            {
                ErrorMsg = null;
                IsLoggedIn = true;
            }
            else
            {
                ErrorMsg = "Bad Bad Bad Bad Bad Login!";
            }
        }

        private string _errorMsg;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set
            {
                _errorMsg = value;
                NotifyPropertyChanged();
            }
        }

        private bool isLoggedIn;

        public bool IsLoggedIn
        {
            get { return isLoggedIn; }
            set
            {
                isLoggedIn = value;
                NotifyPropertyChanged();
            }
        }


    }
}
