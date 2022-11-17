using AnalyzeApp.Model;
using AnalyzeApp.Request;
using AnalyzeApp.Store;
using AnalyzeApp.UserException;
using AnalyzeApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnalyzeApp.Command
{
    class UploadVideoCommand : BaseAsyncCommand
    {
        private UserStore _userStore;
        private VideoLibraryViewModel currentVideoLibraryViewModel;
        private apiReq request = new apiReq();

        public UploadVideoCommand(UserStore userStore, VideoLibraryViewModel currentVideoLibraryViewModel)
        {
            _userStore = userStore;
            this.currentVideoLibraryViewModel = currentVideoLibraryViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            int validFlag = 0;
            if (String.IsNullOrWhiteSpace(currentVideoLibraryViewModel.VideoLocation) || String.IsNullOrWhiteSpace(currentVideoLibraryViewModel.VideoName) || string.IsNullOrWhiteSpace(currentVideoLibraryViewModel.VideoPath))
            {
                validFlag = 1;
                currentVideoLibraryViewModel.ValidationMessageUpload = "Please enter the values";
            }
            bool something = File.Exists(currentVideoLibraryViewModel.VideoPath);
            if (!File.Exists(currentVideoLibraryViewModel.VideoPath))
            {
                validFlag = 1;
                currentVideoLibraryViewModel.ValidationMessageUpload = "File directory not valid";
            }
            try
            {
                if (validFlag == 0)
                {
                    var filepathSplice = currentVideoLibraryViewModel.VideoPath.Split('.');
                    string extension = filepathSplice[filepathSplice.Length - 1];
                    VideoModel video = new VideoModel(0, currentVideoLibraryViewModel.VideoName+"."+extension, "null", currentVideoLibraryViewModel.VideoLocation, _userStore.UserID);

                    var result = await request.postVideo(video);
                    if ((int)result.StatusCode == 409)
                    {
                        currentVideoLibraryViewModel.ValidationMessageUpload = "Video name isn't unique";
                    }
                    else if ((int)result.StatusCode == 201)
                    {
                        var jsonValue = JsonConvert.DeserializeObject<Dictionary<String, String>>(result.Content.ReadAsStringAsync().Result);
                        string fileName = jsonValue["VideoName"];
                        string filePath = currentVideoLibraryViewModel.VideoPath;
                        var outputVal = await Task.Run(()=>request.sendVideo(filePath, fileName, _userStore.UserCredentials.userName, _userStore.UserCredentials.userPassword));
                        String Msg = String.Equals(outputVal, "Completed") ?  "Video has been uploaded" : "Some error occurred";
                        currentVideoLibraryViewModel.ValidationMessageUpload = Msg;
                        currentVideoLibraryViewModel.VideoCollection.Add(JsonConvert.DeserializeObject<VideoModel>(result.Content.ReadAsStringAsync().Result));
                    }
                    else
                    {
                        currentVideoLibraryViewModel.ValidationMessageUpload = "Request invalid";
                    }
                }
                
            }
            catch(Exception e)
            {
                currentVideoLibraryViewModel.ValidationMessageUpload = "Couldn't request the server";
            }
        }
    }
}
