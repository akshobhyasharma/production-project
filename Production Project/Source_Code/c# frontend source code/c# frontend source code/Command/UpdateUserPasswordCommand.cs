using AnalyzeApp.Request;
using AnalyzeApp.Store;
using AnalyzeApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class UpdateUserPasswordCommand : BaseAsyncCommand
    {
        private UserStore userStore;
        private UserInformationViewModel userInformationViewModel;
        private apiReq request = new apiReq();


        public UpdateUserPasswordCommand(UserStore userStore, UserInformationViewModel userInformationViewModel)
        {
            this.userStore = userStore;
            this.userInformationViewModel = userInformationViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                bool validFlag = true;
                Dictionary<string, string> deserializedValues;

                if (String.IsNullOrWhiteSpace(userInformationViewModel.OldPassword) || String.IsNullOrWhiteSpace(userInformationViewModel.NewPassword) || String.IsNullOrWhiteSpace(userInformationViewModel.NewPasswordConfirm))
                {
                    validFlag = false;
                    userInformationViewModel.UserPasswordMsg = "Please enter all the fields.";
                }
                if (!String.Equals(userInformationViewModel.NewPassword, userInformationViewModel.NewPasswordConfirm))
                {
                    validFlag = false;
                    userInformationViewModel.UserPasswordMsg = "The passwords don't match.";

                }
                if (validFlag == true)
                {
                    var response = await request.UpdateUserPassword(userStore.UserID, userInformationViewModel.NewPassword);
                    if ((int)response.StatusCode == 200)
                    {
                        userStore.UserCredentials.userPassword = userInformationViewModel.NewPassword;
                        userInformationViewModel.UserPasswordMsg = "User Password Changed";
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = "Error occurred";
            }
        }
    }
}
