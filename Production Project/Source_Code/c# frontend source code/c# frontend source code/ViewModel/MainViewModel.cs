using AnalyzeApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeApp.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public ViewModelBase currentViewModel => _navigationStore.CurrentViewModel;
        private NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(currentViewModel));
        }

    }
}
