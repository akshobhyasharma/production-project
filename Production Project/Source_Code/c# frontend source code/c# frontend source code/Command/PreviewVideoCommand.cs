using AnalyzeApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Command
{
    class PreviewVideoCommand : BaseCommand
    {
        private VideoLibraryViewModel videoLibraryViewModel;

        public PreviewVideoCommand(VideoLibraryViewModel videoLibraryViewModel)
        {
            this.videoLibraryViewModel = videoLibraryViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                if (videoLibraryViewModel.VideoPath is not null && File.Exists(videoLibraryViewModel.VideoPath))
                {
                    videoLibraryViewModel.VideoPlayerPath = videoLibraryViewModel.VideoPath;
                }
                else
                {
                    videoLibraryViewModel.ValidationMessageUpload = "File doesn't exist";
                }
            }
            catch (Exception ex)
            {
                videoLibraryViewModel.ValidationMessageUpload = "Some error occurred.";
            }
        }
    }
}
