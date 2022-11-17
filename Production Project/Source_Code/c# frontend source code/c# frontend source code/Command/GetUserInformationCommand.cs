using AnalyzeApp.Model;
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
    class GetUserInformationCommand : BaseAsyncCommand
    {
        private UserStore userStore;
        private UserInformationViewModel userInformationViewModel;
        private apiReq Request = new apiReq();

        public GetUserInformationCommand(UserStore userStore, UserInformationViewModel userInformationViewModel)
        {
            this.userStore = userStore;
            this.userInformationViewModel = userInformationViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                String userInfo = await Request.getUserInfo(userStore.UserID);
                var deserializedValue = JsonConvert.DeserializeObject<RecievedInfo>(userInfo);
                if (deserializedValue is not null)
                {
                    userInformationViewModel.EmailInfo = deserializedValue.email;
                    userInformationViewModel.UserNameInfo = deserializedValue.userName;
                    userInformationViewModel.VideoUploadInfo = deserializedValue.videoUploaded;
                }
            }
            catch
            {
                var msg = "Error occurred.";
            }
        }
    }
}
