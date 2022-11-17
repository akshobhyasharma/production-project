using AnalyzeApp.Command;
using AnalyzeApp.Services;
using AnalyzeApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnalyzeApp.ViewModel
{
    class IndexViewModel : ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _password;

        public string PasswordValue
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(PasswordValue));
            }
        }

        private string _signUpUserName;

        public string SignUpUserName
        {
            get { return _signUpUserName; }
            set
            {
                _signUpUserName = value;
                OnPropertyChanged(nameof(SignUpUserName));
            }
        }

        private string _signUpPassword1;

        public string SignUpPassword1
        {
            get { return _signUpPassword1; }
            set
            {
                _signUpPassword1 = value;
                OnPropertyChanged(nameof(SignUpPassword1));
            }
        }

        private string _signUpPassword2;

        public string SignUpPassword2
        {
            get { return _signUpPassword2; }
            set
            {
                _signUpPassword2 = value;
                OnPropertyChanged(nameof(SignUpPassword2));
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _validationMessage;

        public string ValidationMessage
        {
            get { return _validationMessage; }
            set
            {
                _validationMessage = value;
                OnPropertyChanged(nameof(ValidationMessage));
            }
        }

        private string _signUpValidationMessage;
        public string SignUpValidationMessage
        {
            get { return _signUpValidationMessage; }
            set
            {
                _signUpValidationMessage = value;
                OnPropertyChanged(nameof(SignUpValidationMessage));
            }
        }


        public ICommand LoginCommand { get; }
        public ICommand SignUpCommand { get; }

        public IndexViewModel(UserStore userStore, NavigationService navigationService)
        {
            LoginCommand = new LoginCommand(this, userStore, navigationService);
            SignUpCommand = new SignUpCommand(this);
        }



    }
}
