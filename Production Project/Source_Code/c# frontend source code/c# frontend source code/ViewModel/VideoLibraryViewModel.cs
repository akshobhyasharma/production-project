using AnalyzeApp.Command;
using AnalyzeApp.Model;
using AnalyzeApp.Services;
using AnalyzeApp.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AnalyzeApp.ViewModel
{
    class VideoLibraryViewModel : ViewModelBase
    {
        private ObservableCollection<VideoModel> _videoCollection;
        public ObservableCollection<VideoModel> VideoCollection
        {
            get { return _videoCollection; }
            set
            {
                _videoCollection = value;
                OnPropertyChanged(nameof(VideoCollection));

            }
        }

        private VideoModel selectedVideo;

        public VideoModel SelectedVideo
        {
            get { return selectedVideo; }
            set
            {
                selectedVideo = value;
                OnPropertyChanged(nameof(VideoCollection));
            }
        }


        private string _videoName;

        public string VideoName
        {
            get { return _videoName; }
            set
            {
                _videoName = value;
                OnPropertyChanged(nameof(VideoName));
            }
        }

        private string _videoLocation;

        public string VideoLocation
        {
            get { return _videoLocation; }
            set
            {
                _videoLocation = value;
                OnPropertyChanged(nameof(VideoLocation));
            }
        }

        private string _videoPath;

        public string VideoPath
        {
            get { return _videoPath; }
            set
            {
                _videoPath = value;
                OnPropertyChanged(nameof(VideoPath));
            }
        }

        private string _validationMessageUpload;

        public string ValidationMessageUpload
        {
            get { return _validationMessageUpload; }
            set
            {
                _validationMessageUpload = value;
                OnPropertyChanged(nameof(ValidationMessageUpload));
            }
        }

        private string _updateName;

        public string UpdateName
        {
            get { return _updateName; }
            set
            {
                _updateName = value;
                OnPropertyChanged(nameof(UpdateName));
            }
        }

        private string _updateLocation;

        public string UpdateLocation
        {
            get { return _updateLocation; }
            set
            {
                _updateLocation = value;
                OnPropertyChanged(nameof(UpdateLocation));
            }
        }


        private string _delUpdateMsg;
        public string DelUpdateMsg
        {
            get { return _delUpdateMsg; }
            set
            {
                _delUpdateMsg = value;
                OnPropertyChanged(nameof(DelUpdateMsg));
            }
        }

        private string _updateMessage;

        public string UpdateMessage
        {
            get { return _updateMessage; }
            set
            {
                _updateMessage = value;
                OnPropertyChanged(nameof(UpdateMessage));
            }
        }

        private String _videoPlayerPath;
        public String VideoPlayerPath
        {
            get { return _videoPlayerPath; }
            set
            {
                _videoPlayerPath = value;
                OnPropertyChanged(nameof(VideoPlayerPath));
            }
        }

        public UserStore userStore;


        public ICommand DeleteVideoCommand { get; }
        public ICommand UploadVideoCommand { get; }
        public ICommand UpdateVideoCommand { get; }
        public ICommand NavigateUserInfo { get; }
        public ICommand NavigateVideoAnalyze { get; }
        public ICommand GetVideoListCommand { get; }
        public ICommand EditVideoCommand { get; }
        public ICommand PreviewVideoCommand { get; }

        public VideoLibraryViewModel(UserStore userStore, NavigationService navigationServiceAnalyze, NavigationService navigationServiceUserInfo)
        {
            _videoCollection = new ObservableCollection<VideoModel>();
            UploadVideoCommand = new UploadVideoCommand(userStore, this);
            GetVideoListCommand = new GetVideoListCommand(userStore, this);
            DeleteVideoCommand = new DeleteVideoCommand(userStore, this);
            UpdateVideoCommand = new UpdateVideoCommand(userStore, this);
            EditVideoCommand = new EditVideoCommand(this);
            NavigateUserInfo = new NavigateCommand(navigationServiceUserInfo);
            NavigateVideoAnalyze = new NavigateCommand(navigationServiceAnalyze);
            PreviewVideoCommand = new PreviewVideoCommand(this);
            userStore = userStore;
        }

        public static VideoLibraryViewModel LoadVideoLibraryViewModel(UserStore userStore, NavigationService navigationServiceAnalyze, NavigationService navigationServiceUserInfo)
        {
            VideoLibraryViewModel viewModel = new VideoLibraryViewModel(userStore, navigationServiceAnalyze, navigationServiceUserInfo);
            viewModel.GetVideoListCommand.Execute(null);

            return viewModel;
        }

        public void PropertyChangeNotifier(string PropertyName)
        {
            OnPropertyChanged(PropertyName);
        }
    }
}
