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
    class UserInformationViewModel : ViewModelBase
    {
        private UserStore userStore;
        public ICommand NavigateVideoLibrary { get; }
        public ICommand NavigateVideoAnalyze { get; }
        public ICommand UpdateUserInfo { get; }
        public ICommand UpdateUserPassword { get; }
        public ICommand DeleteUserAccount { get; }
        public GetUserInformationCommand GetUserInformationCommand { get; }

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



        private string _oldPassword;

        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                _oldPassword = value;
                OnPropertyChanged(nameof(OldPassword));
            }
        }

        private string _newPassword;

        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                _newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string _newPasswordConfirm;

        public string NewPasswordConfirm
        {
            get { return _newPasswordConfirm; }
            set
            {
                _newPasswordConfirm = value;
                OnPropertyChanged(nameof(NewPasswordConfirm));
            }
        }

        private string _userInfoMsg;

        public string UserInfoMsg
        {
            get { return _userInfoMsg; }
            set
            {
                _userInfoMsg = value;
                OnPropertyChanged(nameof(UserInfoMsg));
            }
        }

        private string _userPasswordMsg;

        public string UserPasswordMsg
        {
            get { return _userPasswordMsg; }
            set
            {
                _userPasswordMsg = value;
                OnPropertyChanged(nameof(UserPasswordMsg));

            }
        }

        private int _videoUploadInfo;

        public int VideoUploadInfo
        {
            get { return _videoUploadInfo; }
            set { _videoUploadInfo = value; 
                OnPropertyChanged(nameof(VideoUploadInfo));
            }
        }

        private string _emailInfo;

        public string EmailInfo
        {
            get { return _emailInfo; }
            set { _emailInfo = value; 
                OnPropertyChanged(nameof(EmailInfo));
            }
        }

        private string _userNameInfo;

        public string UserNameInfo
        {
            get { return _userNameInfo; }
            set { _userNameInfo = value; 
                OnPropertyChanged(nameof(UserNameInfo));
            }
        }




        public UserInformationViewModel(UserStore userStore, NavigationService navigationServiceVideoLibrary, NavigationService navigationServiceVideoAnalyze, NavigationService navigationServiceIndex)
        {
            this.userStore = userStore;
            NavigateVideoLibrary = new NavigateCommand(navigationServiceVideoLibrary);
            NavigateVideoAnalyze = new NavigateCommand(navigationServiceVideoAnalyze);
            UpdateUserInfo = new UpdateUserInfoCommand(userStore, this);
            UpdateUserPassword = new UpdateUserPasswordCommand(userStore,this);
            DeleteUserAccount = new DeleteUserCommand(userStore,navigationServiceIndex);
            GetUserInformationCommand = new GetUserInformationCommand(userStore, this);
        }

        public static UserInformationViewModel LoadInformationViewModel(UserStore userStore, NavigationService navigationServiceVideoLibrary, NavigationService navigationServiceVideoAnalyze, NavigationService navigationServiceIndex)
        {
            UserInformationViewModel viewModel = new UserInformationViewModel(userStore, navigationServiceVideoLibrary, navigationServiceVideoAnalyze, navigationServiceIndex);
            viewModel.GetUserInformationCommand.Execute(null);
            return viewModel;
        }
    }
}
