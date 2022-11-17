using AnalyzeApp.Model;
using AnalyzeApp.Request;
using AnalyzeApp.Services;
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
    class LoginCommand : BaseCommand
    {
        private UserStore userStore;
        private NavigationService navigationService;
        private string? userName;
        private string? password;
        private IndexViewModel currentIndexView;
        private apiReq request = new apiReq();

        public LoginCommand(IndexViewModel CurrentIndexView, UserStore userStore, NavigationService navigationService)
        {
            this.userStore = userStore;
            this.navigationService = navigationService;
            currentIndexView = CurrentIndexView;
        }

        public override void Execute(object? parameter)
        {
            userName = currentIndexView.UserName;
            password = currentIndexView.PasswordValue;
            int validFlag = 1;
            Dictionary<string, string> values;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
            {
                validFlag = 0;
                currentIndexView.ValidationMessage = "Enter all Login credentials.";
            }
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                validFlag = 0;
                currentIndexView.ValidationMessage = "Enter all login credentials.";
            }
            if (validFlag == 1)
            {
                try
                {
                    string result = request.checkUser(userName, password);
                    values = JsonConvert.DeserializeObject<Dictionary<String, String>>(result);
                    if (values.ContainsKey("message"))
                    {
                        currentIndexView.ValidationMessage = values["message"];
                    }
                    else if (values.ContainsValue(userName))
                    {
                        userStore.UserCredentials = new AuthenticatedUser(userName, password);
                        userStore.UserID = int.Parse(values["UserID"]);
                        navigationService.Navigate();
                    }
                }catch(Exception ex)
                {
                    currentIndexView.ValidationMessage = "Couldn't connect to the database.";
                }
            }
            
        }
    }
}
