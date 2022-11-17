using AnalyzeApp.Store;
using AnalyzeApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class VideoListClickCommand : BaseCommand
    {
        private UserStore userStore;
        private VideoAnalyzeViewModel videoAnalyzeViewModel;

        public VideoListClickCommand(UserStore userStore, VideoAnalyzeViewModel videoAnalyzeViewModel)
        {
            this.userStore = userStore;
            this.videoAnalyzeViewModel = videoAnalyzeViewModel;
        }

        public override void Execute(object? parameter)
        {
            var currentVideo = videoAnalyzeViewModel.SelectedSplice;
            if (videoAnalyzeViewModel.RecievedVideoCollection is not null)
            {
                videoAnalyzeViewModel.SpliceStartTime = currentVideo.starttime.ToString();
                videoAnalyzeViewModel.SpliceEndTime = currentVideo.endTime.ToString();
                videoAnalyzeViewModel.SpliceVideoName = currentVideo.videoName;
                videoAnalyzeViewModel.ObjectItems = currentVideo.objectList;
                videoAnalyzeViewModel.VideoPath = "./SavedVideo/" + currentVideo.spliceName;
            }
        }
    }
}
