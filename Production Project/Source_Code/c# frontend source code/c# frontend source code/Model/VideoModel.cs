using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.Model
{
    public class VideoModel : INotifyPropertyChanged
    {
        DateTime currentTime = DateTime.Now;
        public VideoModel(int videoID, string videoName, string videoPath, string videoLocation, int userID)
        {
            this.videoID = videoID;
            this.videoName = videoName;
            this.videoPath = videoPath;
            this.videoLocation = videoLocation;
            this.videoTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, currentTime.Hour, currentTime.Minute, currentTime.Second);
            this.userID = userID;
        }

        public int videoID { get; set; }

        public string videoName;
        public string VideoName
        {
            get { return videoName; }
            set
            {
                videoName = value;
                OnPropertyChanged(nameof(videoName));
            }
        }

        public string videoLocation;

        public string VideoLocation
        {
            get { return videoLocation; }
            set
            {
                videoLocation = value;
                OnPropertyChanged(nameof(videoLocation));
            }
        }



        public string videoPath { get; set; }
        public DateTime videoTime { get; set; }
        public int userID { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
