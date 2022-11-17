using AnalyzeApp.Model;
using AnalyzeApp.Request;
using AnalyzeApp.Store;
using AnalyzeApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class GetVideoListCommand : BaseAsyncCommand
    {
        private UserStore userStore;
        private ViewModelBase ViewModel;
        private apiReq Request = new apiReq();

        public GetVideoListCommand(UserStore userStore, ViewModelBase videoLibraryViewModel)
        {
            this.userStore = userStore;
            this.ViewModel = videoLibraryViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                String videoInfo = await Request.getAllVideo(userStore.UserID);
                var deserializedValue = JsonConvert.DeserializeObject<ObservableCollection<VideoModel>>(videoInfo);

                if(ViewModel is VideoLibraryViewModel)
                {
                    VideoLibraryViewModel videoLibraryViewModel = (VideoLibraryViewModel)ViewModel;
                    videoLibraryViewModel.VideoCollection = deserializedValue;
                }
                else if(ViewModel is VideoAnalyzeViewModel)
                {
                    VideoAnalyzeViewModel videoAnalyzeViewModel = (VideoAnalyzeViewModel)ViewModel;
                    videoAnalyzeViewModel.VideoCollection = deserializedValue;
                }
            }
            catch(Exception ex)
            {
                var msg = "something was wrong";
            }
        }
    }
}
