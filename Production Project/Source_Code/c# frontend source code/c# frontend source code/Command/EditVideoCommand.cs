using AnalyzeApp.Store;
using AnalyzeApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class EditVideoCommand : BaseCommand
    {
        private VideoLibraryViewModel videoLibraryViewModel;

        public EditVideoCommand(VideoLibraryViewModel videoLibraryViewModel)
        {
            this.videoLibraryViewModel = videoLibraryViewModel;
        }

        public override void Execute(object? parameter)
        {
            var Name = videoLibraryViewModel.SelectedVideo.videoName.Split('.');
            videoLibraryViewModel.UpdateName = Name[0];
            videoLibraryViewModel.UpdateLocation = videoLibraryViewModel.SelectedVideo.videoLocation;
        }
    }
}
