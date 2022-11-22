using System;
using System.Collections.Generic;
using System.Text;
using KPZ_WPF_LAB_2.NavigationViews;
using KPZ_WPF_LAB_2.ViewModel;

namespace KPZ_WPF_LAB_2.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationScheduleManager _navigationScheduleManager;
        private readonly Func<TViewModel> createViewModel;

        public NavigateCommand(NavigationScheduleManager navigationScheduleManager, Func<TViewModel> createViewModel)
        {
            _navigationScheduleManager = navigationScheduleManager;
            this.createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationScheduleManager.CurrentViewModel = createViewModel();
        }
    }
}
