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
    class UpdateVideoCommand:BaseAsyncCommand
    {
        private UserStore userStore;
        private VideoLibraryViewModel videoLibraryViewModel;
        private apiReq request = new apiReq();

        public UpdateVideoCommand(UserStore userStore, VideoLibraryViewModel videoLibraryViewModel)
        {
            this.userStore = userStore;
            this.videoLibraryViewModel = videoLibraryViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var currentVid = videoLibraryViewModel.SelectedVideo;
            try
            {
                bool validFlag = true;

                if (String.IsNullOrWhiteSpace(videoLibraryViewModel.UpdateName)||String.IsNullOrWhiteSpace(videoLibraryViewModel.UpdateLocation))
                {
                    validFlag = false;
                    videoLibraryViewModel.UpdateMessage = "Please enter the values.";
                }
                if(validFlag == true)
                {
                    var extensionSplit = currentVid.VideoName.Split('.');
                    var extension = extensionSplit[extensionSplit.Length - 1];
                    VideoModel video = new VideoModel(currentVid.videoID, videoLibraryViewModel.UpdateName+"."+extension, currentVid.videoPath, videoLibraryViewModel.UpdateLocation, currentVid.userID);
                    var updateResponse = await request.updateVideo(video);

                    if ((int)updateResponse.StatusCode == 404)
                    {
                        videoLibraryViewModel.UpdateMessage = "The video doesn't exist.";
                    }
                    else if((int)updateResponse.StatusCode == 204)
                    {
                        videoLibraryViewModel.UpdateMessage = "Video info Updated.";
                        currentVid.VideoName = videoLibraryViewModel.UpdateName+"."+extension;
                        currentVid.VideoLocation = videoLibraryViewModel.UpdateLocation;
                    }
                }
            }
            catch
            {
                var msg = "error occurred";
            }
        }
    }
}
