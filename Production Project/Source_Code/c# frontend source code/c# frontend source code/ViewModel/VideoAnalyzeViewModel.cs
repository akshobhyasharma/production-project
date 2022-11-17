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
using System.Windows.Controls;
using System.Windows.Input;

namespace AnalyzeApp.ViewModel
{
    class VideoAnalyzeViewModel : ViewModelBase
    {
        public event EventHandler videoChanged;

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

        private ObservableCollection<SpliceRecieved> _recievedVideoCollection = new ObservableCollection<SpliceRecieved>();
        public ObservableCollection<SpliceRecieved> RecievedVideoCollection
        {
            get { return _recievedVideoCollection; }
            set
            {
                _recievedVideoCollection = value;
                OnPropertyChanged(nameof(RecievedVideoCollection));

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

        private SpliceRecieved _selectedSplice;

        public SpliceRecieved SelectedSplice
        {
            get { return _selectedSplice; }
            set
            {
                _selectedSplice = value;
                OnPropertyChanged(nameof(SelectedSplice));
                if (SelectedSplice is not null)
                {
                    VideoListClick.Execute(null);
                }                
            }
        }



        private string _spliceMessage;

        public string SpliceMessage
        {
            get { return _spliceMessage; }
            set
            {
                _spliceMessage = value;
                OnPropertyChanged(nameof(SpliceMessage));
            }
        }

        private bool _carChecked = true;

        public bool CarChecked
        {
            get { return _carChecked; }
            set
            {
                _carChecked = value;
                OnPropertyChanged(nameof(CarChecked));
            }
        }

        private bool _bikeChecked;

        public bool BikeChecked
        {
            get { return _bikeChecked; }
            set
            {
                _bikeChecked = value;
                OnPropertyChanged(nameof(BikeChecked));
            }
        }

        private bool _busChecked;

        public bool BusChecked
        {
            get { return _busChecked; }
            set
            {
                _busChecked = value;
                OnPropertyChanged(nameof(BusChecked));
            }
        }

        private bool _truckChecked;

        public bool TruckChecked
        {
            get { return _truckChecked; }
            set
            {
                _truckChecked = value;
                OnPropertyChanged(nameof(TruckChecked));
            }
        }

        private bool _personChecked;

        public bool PersonChecked
        {
            get { return _personChecked; }
            set
            {
                _personChecked = value;
                OnPropertyChanged(nameof(PersonChecked));
            }
        }

        private bool _detailedChecked;

        public bool DetailedChecked
        {
            get { return _detailedChecked; }
            set
            {
                _detailedChecked = value;
                OnPropertyChanged(nameof(DetailedChecked));
            }
        }

        private bool _averageChecked = true;

        public bool AverageChecked
        {
            get { return _averageChecked; }
            set
            {
                _averageChecked = value;
                OnPropertyChanged(nameof(AverageChecked));
            }
        }

        private bool _quickChecked;

        public bool QuickChecked
        {
            get { return _quickChecked; }
            set
            {
                _quickChecked = value;
                OnPropertyChanged(nameof(QuickChecked));
            }
        }

        private string _spliceVideoname;

        public string SpliceVideoName
        {
            get { return _spliceVideoname; }
            set
            {
                _spliceVideoname = value;
                OnPropertyChanged(nameof(SpliceVideoName));
            }
        }

        private string _spliceStartTime;

        public string SpliceStartTime
        {
            get { return _spliceStartTime; }
            set
            {
                _spliceStartTime = value;
                OnPropertyChanged(nameof(SpliceStartTime));
            }
        }

        private string _spliceEndTime;

        public string SpliceEndTime
        {
            get { return _spliceEndTime; }
            set
            {
                _spliceEndTime = value;
                OnPropertyChanged(nameof(SpliceEndTime));
            }
        }

        private List<String> _objectItems;

        public List<String> ObjectItems
        {
            get { return _objectItems; }
            set
            {
                _objectItems = value;
                OnPropertyChanged(nameof(ObjectItems));
            }
        }

        private String _videoPath;
        public String VideoPath
        {
            get { return _videoPath; }
            set
            {
                _videoPath = value;
                OnPropertyChanged(nameof(VideoPath));
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }





        private ObservableCollection<VideoModel> _userCollection = new ObservableCollection<VideoModel>();
        private UserStore userStore;
        public ICommand NavigateVideoLibrary { get; }
        public ICommand NavigateUserInfo { get; }
        public ICommand SpliceVideo { get; }
        public ICommand GetVideoList { get; }
        public ICommand OpenDirectory { get; }
        public VideoListClickCommand VideoListClick { get; }


        public VideoAnalyzeViewModel(UserStore userStore, NavigationService navigationServiceVideoLibrary, NavigationService navigationServiceUserInfo)
        {
            this.userStore = userStore;
            NavigateVideoLibrary = new NavigateCommand(navigationServiceVideoLibrary);
            NavigateUserInfo = new NavigateCommand(navigationServiceUserInfo);
            GetVideoList = new GetVideoListCommand(userStore, this);
            SpliceVideo = new SpliceCommand(userStore, this);
            VideoListClick = new VideoListClickCommand(userStore, this);
            OpenDirectory = new OpenDirectoryCommand();
        }

        public static VideoAnalyzeViewModel LoadVideoAnalyzeViewModel(UserStore userStore, NavigationService navigationServiceVideoLibrary, NavigationService navigationServiceUserInfo)
        {
            VideoAnalyzeViewModel viewModel = new VideoAnalyzeViewModel(userStore, navigationServiceVideoLibrary, navigationServiceUserInfo);
            viewModel.GetVideoList.Execute(null);
            return viewModel;
        }
    }
}
