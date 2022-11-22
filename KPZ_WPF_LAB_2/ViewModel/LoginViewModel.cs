using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Text;
using System.Windows.Input;
using KPZ_WPF_LAB_2.Commands;
using KPZ_WPF_LAB_2.Models;
using KPZ_WPF_LAB_2.NavigationViews;

namespace KPZ_WPF_LAB_2.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _name;
        private string _password;
        private string _errorMessage;
        public NavigationScheduleManager NavigationScheduleManager { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }


        public ICommand LoginCommand { get; }
        public ICommand NavigateToUserMainPage { get; set; }

        public LoginViewModel(NavigationScheduleManager navigationScheduleManager, DataModel model)
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            NavigationScheduleManager = navigationScheduleManager;
            DataModel = model;
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;

            if (string.IsNullOrWhiteSpace(Name) || Name.Length < 3
                || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;

            return validData;
        }

        private void ExecuteLoginCommand(object obj)
        {
            
            if (DataModel.Doctors.Exists(d => d.Username == Name && d.Password == Password))
            {
                NavigationScheduleManager.CurrentViewModel = new DoctorViewModel(NavigationScheduleManager, DataModel, DataModel.Doctors.Find(d => d.Username == Name && d.Password == Password));
                //NavigateToUserMainPage = new NavigateCommand<DoctorViewModel>(NavigationScheduleManager, () => new DoctorViewModel(NavigationScheduleManager));
                return;
            }
            else if (DataModel.Administrators.Exists(a => a.Username == Name && a.Password == Password))
            {
                NavigationScheduleManager.CurrentViewModel = new AdminViewModel(NavigationScheduleManager, DataModel, DataModel.Administrators.Find(a => a.Username == Name && a.Password == Password));

                //NavigateToUserMainPage = new NavigateCommand<AdminViewModel>(NavigationScheduleManager, () => new AdminViewModel(NavigationScheduleManager));
                return;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
                return;
            }

        }
    }
}
