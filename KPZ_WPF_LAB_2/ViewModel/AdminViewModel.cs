using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using KPZ_WPF_LAB_2.Commands;
using KPZ_WPF_LAB_2.Models;
using KPZ_WPF_LAB_2.NavigationViews;

namespace KPZ_WPF_LAB_2.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        public Administrator Administrator { get; set; }

        public DayScheduleEditorViewModel _dayScheduleEditorViewModel;

        public Doctor _doctor;

        public TimeSpan _interval;

        public TimeSpan _startWorkDay;

        public TimeSpan _endWorkDay;

        public DateTime _currentDate;
        public List<DaySchedule> Schedule { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        private DaySchedule _daySchedule;

        public Doctor Doctor
        {
            get => _doctor;
            set
            {
                _doctor = value;
                OnPropertyChanged(nameof(Doctor));
            }
        }
        public DaySchedule DaySchedule
        {
            get => _daySchedule;
            set
            {
                _daySchedule = value;
                OnPropertyChanged(nameof(DaySchedule));
            }
        }

        public DayScheduleEditorViewModel DayScheduleEditorViewModel
        {
            get => _dayScheduleEditorViewModel;
            set
            {
                _dayScheduleEditorViewModel = value;
                OnPropertyChanged(nameof(DayScheduleEditorViewModel));
            }
        }

        public TimeSpan Interval
        {
            get => _interval;
            set
            {
                _interval = value;
                OnPropertyChanged(nameof(Interval));
            }
        }

        public TimeSpan StartWorkDay
        {
            get => _startWorkDay;
            set
            {
                _startWorkDay = value;
                OnPropertyChanged(nameof(StartWorkDay));
            }
        }

        public TimeSpan EndWorkDay
        {
            get => _endWorkDay;
            set
            {
                _endWorkDay = value;
                OnPropertyChanged(nameof(EndWorkDay));
            }
        }
        public DateTime CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                OnPropertyChanged(nameof(CurrentDate));
            }
        }
        public ICommand NavigateLoginCommand { get; }
        public ICommand ChooseDoctorCommand { get; }
        public ICommand DatePickerCommand { get; }
        public ICommand CreateDayScheduleCommand { get; }
        public ICommand SwitchModeCommand { get; }


        public AdminViewModel(NavigationScheduleManager navigationScheduleManager, DataModel model, Administrator administrator)
        {
            Administrator = administrator;
            DataModel = model;
            CurrentDate = DateTime.Now;
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationScheduleManager, () => new LoginViewModel(navigationScheduleManager, model));
            ChooseDoctorCommand = new ViewModelCommand(ExecuteChooseDoctor, CanExecuteChooseDoctor);
            DatePickerCommand = new ViewModelCommand(ExecuteDatePicker, CanExecuteDatePickerCommand);
            CreateDayScheduleCommand = new ViewModelCommand(ExecuteCreateDaySchedule, CanExecuteCreateDaySchedule);
            SwitchModeCommand = new ViewModelCommand(ExecuteSwitchModeCommand, CanExecuteSwitchModeCommand);
        }

        private bool CanExecuteSwitchModeCommand(object obj) => true;
      
        private void ExecuteSwitchModeCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteCreateDaySchedule(object obj) => true;

        private void ExecuteCreateDaySchedule(object obj)
        {
            Schedule.Add(new DaySchedule(DayScheduleEditorViewModel.StartWorkDay,
                DayScheduleEditorViewModel.EndWorkDay, DayScheduleEditorViewModel.Interval, CurrentDate, new List<Record>()));
        }

        private void ExecuteDatePicker(object obj)
        {
            DaySchedule = Schedule.Find(x => Math.Floor(x.DayScheduleDate.ToOADate()).Equals(Math.Floor(CurrentDate.ToOADate())));
            //CurrentDate = DaySchedule.DayScheduleDate;
        }

        private bool CanExecuteDatePickerCommand(object obj) => true;

        private bool CanExecuteChooseDoctor(object obj) => true;

        private void ExecuteChooseDoctor(object obj)
        {
            Doctor = DataModel.Doctors.Find(x => x.Name == Name && x.Surname == Surname);
        }
    }
}
