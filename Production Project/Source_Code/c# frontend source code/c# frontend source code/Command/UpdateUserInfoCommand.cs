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
    class UpdateUserInfoCommand : BaseAsyncCommand
    {
        private UserStore userStore;
        private UserInformationViewModel userInformationViewModel;
        private apiReq request = new apiReq();

        public UpdateUserInfoCommand(UserStore userStore, UserInformationViewModel userInformationViewModel)
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

                if (String.IsNullOrWhiteSpace(userInformationViewModel.UserName) || String.IsNullOrWhiteSpace(userInformationViewModel.Email))
                {
                    validFlag = false;
                }
                if (validFlag == true)
                {
                    string result = request.checkUsername(userInformationViewModel.UserName, userInformationViewModel.Email);
                    deserializedValues = JsonConvert.DeserializeObject<Dictionary<String, String>>(result);
                    if (deserializedValues.ContainsKey("message"))
                    {
                        if (!String.Equals(deserializedValues["message"], "available"))
                        {
                            userInformationViewModel.UserInfoMsg = deserializedValues["message"];
                        }
                        else
                        {
                            var response =await request.UpdateUserInfo(userStore.UserID, userInformationViewModel.UserName, userInformationViewModel.Email);
                            if ((int)response.StatusCode == 200)
                            {
                                userStore.UserCredentials.userName = userInformationViewModel.UserName;
                                userInformationViewModel.UserInfoMsg = "Usern Information changed";

                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var     msg = "Error occurred";
            }
        }
    }
}
