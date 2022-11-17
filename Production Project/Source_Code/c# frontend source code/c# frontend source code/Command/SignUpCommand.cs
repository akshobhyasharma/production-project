using AnalyzeApp.Request;
using AnalyzeApp.Services;
using AnalyzeApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class SignUpCommand : BaseCommand
    {
        private IndexViewModel indexViewModel;
        private apiReq request = new apiReq();

        public SignUpCommand(IndexViewModel indexViewModel)
        {
            this.indexViewModel = indexViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                int validFlag = 0;
                Dictionary<string, string> deserializedValues;

                if (String.IsNullOrWhiteSpace(indexViewModel.SignUpPassword1) || String.IsNullOrWhiteSpace(indexViewModel.SignUpPassword2) || String.IsNullOrWhiteSpace(indexViewModel.SignUpUserName) || String.IsNullOrWhiteSpace(indexViewModel.Email))
                {
                    validFlag = 1;
                    indexViewModel.SignUpValidationMessage = "Please enter all the necessary fields.";
                }
                if (!String.Equals(indexViewModel.SignUpPassword1, indexViewModel.SignUpPassword2))
                {
                    validFlag = 1;
                    indexViewModel.SignUpValidationMessage = "Password doesn't match.";

                }
                if (validFlag == 0)
                {
                    string result = request.checkUsername(indexViewModel.SignUpUserName, indexViewModel.Email);
                    deserializedValues = JsonConvert.DeserializeObject<Dictionary<String, String>>(result);
                    if (deserializedValues.ContainsKey("message"))
                    {
                        if (!String.Equals(deserializedValues["message"], "available"))
                        {
                            indexViewModel.SignUpValidationMessage = deserializedValues["message"];
                        }
                        else
                        {
                            result = request.postUser(indexViewModel.UserName, indexViewModel.Email, indexViewModel.SignUpPassword1, "User", 0);
                            deserializedValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                            if (deserializedValues.ContainsKey("message"))
                            {
                                indexViewModel.SignUpValidationMessage = deserializedValues["message"];
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                indexViewModel.SignUpValidationMessage = "Couldn't connect to the database.";
            }
        }
    }
}
