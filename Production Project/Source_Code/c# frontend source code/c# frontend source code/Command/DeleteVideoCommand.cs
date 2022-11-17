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
    class DeleteVideoCommand:BaseAsyncCommand
    {
        private UserStore userStore;
        private VideoLibraryViewModel videoLibraryViewModel;
        private apiReq request = new apiReq();

        public DeleteVideoCommand(UserStore userStore, VideoLibraryViewModel videoLibraryViewModel)
        {
            this.userStore = userStore;
            this.videoLibraryViewModel = videoLibraryViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                bool validFlag = true;

                if(videoLibraryViewModel.SelectedVideo == null)
                {
                    validFlag = false;
                    videoLibraryViewModel.DelUpdateMsg = "Select an item to delete.";
                }

                if (validFlag == true)
                {
                    var requestResponse = await request.deleteVideo(videoLibraryViewModel.SelectedVideo.videoID);
                    if ((int)requestResponse.StatusCode == 404)
                    {
                        videoLibraryViewModel.DelUpdateMsg = "The video doesn't exist";
                    }
                    else if ((int)requestResponse.StatusCode == 417)
                    {
                        videoLibraryViewModel.DelUpdateMsg = "Deleted from database.";
                        videoLibraryViewModel.VideoCollection.Remove(videoLibraryViewModel.SelectedVideo);
                    }
                    else if ((int)requestResponse.StatusCode == 200)
                    {
                        videoLibraryViewModel.DelUpdateMsg = "Video has been deleted.";
                        videoLibraryViewModel.VideoCollection.Remove(videoLibraryViewModel.SelectedVideo);
                    }
                }
            }
            catch(Exception ex)
            {
                var Msg = "Something wrong happened.";
            }
        }
    }
}
