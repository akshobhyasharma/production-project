using AnalyzeApp.Services;
using AnalyzeApp.Store;
using AnalyzeApp.View;
using AnalyzeApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AnalyzeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private UserStore _userStore;
        public App()
        {
            _navigationStore = new NavigationStore();
            _userStore = new UserStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateIndexViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private IndexViewModel CreateIndexViewModel()
        {
            return new IndexViewModel(_userStore, new NavigationService(_navigationStore, CreateVideoLibraryViewModel));
        }

        private VideoLibraryViewModel CreateVideoLibraryViewModel()
        {
            return VideoLibraryViewModel.LoadVideoLibraryViewModel(_userStore,new NavigationService(_navigationStore,CreateVideoAnalyzeViewModel),new NavigationService(_navigationStore,CreateUserInformationViewModel));
        }

        private VideoAnalyzeViewModel CreateVideoAnalyzeViewModel()
        {
            return VideoAnalyzeViewModel.LoadVideoAnalyzeViewModel(_userStore, new NavigationService(_navigationStore,CreateVideoLibraryViewModel), new NavigationService(_navigationStore,CreateUserInformationViewModel));
        }

        private UserInformationViewModel CreateUserInformationViewModel()
        {
            return UserInformationViewModel.LoadInformationViewModel(_userStore, new NavigationService(_navigationStore,CreateVideoLibraryViewModel), new NavigationService(_navigationStore, CreateVideoAnalyzeViewModel), new NavigationService(_navigationStore, CreateIndexViewModel));
        }
    }
}
