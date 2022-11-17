using AnalyzeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.UserException
{
    class VideoUploadException : Exception
    {
        public VideoModel ExistingVideo { get; }
        public VideoModel IncomingVideo { get; }

        public VideoUploadException(string? message, VideoModel existingVideo, VideoModel incomingVideo) : base(message)
        {
            ExistingVideo = existingVideo;
            IncomingVideo = incomingVideo;
        }

        public VideoUploadException(string? message, Exception? innerException, VideoModel existingVideo, VideoModel incomingVideo) : base(message, innerException)
        {
            ExistingVideo = existingVideo;
            IncomingVideo = incomingVideo;
        }

        public VideoUploadException(VideoModel existingVideo, VideoModel incomingVideo)
        {
            ExistingVideo = existingVideo;
            IncomingVideo = incomingVideo;
        }
    }
}
