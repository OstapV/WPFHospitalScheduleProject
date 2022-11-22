using System;
using System.Collections.Generic;
using System.Text;
using KPZ_WPF_LAB_2.ViewModel;

namespace KPZ_WPF_LAB_2.NavigationViews
{
    public class NavigationScheduleManager
    {
        public event Action CurrentViewModelChanged;

        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
