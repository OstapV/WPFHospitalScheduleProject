using System;
using System.Collections.Generic;
using System.Text;
using KPZ_WPF_LAB_2.Models;
using KPZ_WPF_LAB_2.NavigationViews;

namespace KPZ_WPF_LAB_2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationScheduleManager _navigationScheduleManager;
        public ViewModelBase CurrentViewModel => _navigationScheduleManager.CurrentViewModel;
        public MainViewModel(NavigationScheduleManager navigation, DataModel model)  
        {
            _navigationScheduleManager = navigation;
            _navigationScheduleManager.CurrentViewModelChanged += OnCurrentViewModelChanged;
            DataModel = model;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
