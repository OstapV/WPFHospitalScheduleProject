using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using KPZ_WPF_LAB_2.Commands;
using KPZ_WPF_LAB_2.Models;
using KPZ_WPF_LAB_2.NavigationViews;

namespace KPZ_WPF_LAB_2.ViewModel
{
    public class DoctorViewModel : ViewModelBase
    {
        //public Schedule Schedule { get; set; }

        public TimeSpan _interval;

        public TimeSpan _startWorkDay;

        public TimeSpan _endWorkDay;

        public DateTime _currentDate;

        public DayScheduleEditorViewModel _dayScheduleEditorViewModel;

        private DaySchedule _daySchedule;

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

        public DaySchedule DaySchedule 
        { 
            get => _daySchedule;
            set
            {
                _daySchedule = value;
                OnPropertyChanged(nameof(DaySchedule));
            } 
        }

        public List<DaySchedule> Schedule { get; set; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand DatePickerCommand { get; }
        public ICommand CreateDayScheduleCommand { get; }

        //C:\Users\lenovo\OneDrive\Робочий стіл\3 курс\1 семестр\КПЗ\КПЗ_ЛАБ_2_ТЕСТ\KPZ_WPF_LAB_2\KPZ_WPF_LAB_2\KPZ_WPF_LAB_2.sln
        public DoctorViewModel(NavigationScheduleManager navigationScheduleManager, DataModel model, Doctor doctor)
        {
            Schedule = doctor.DoctorSchedule;
            CurrentDate = DateTime.Now;
            DataModel = model;
            DayScheduleEditorViewModel = new DayScheduleEditorViewModel();
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationScheduleManager, () => new LoginViewModel(navigationScheduleManager, model));
            DatePickerCommand = new ViewModelCommand(ExecuteDatePicker, CanExecuteDatePickerCommand);
            CreateDayScheduleCommand = new ViewModelCommand(ExecuteCreateDaySchedule, CanExecuteCreateDaySchedule);
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

        private bool CanExecuteDatePickerCommand(object obj)
        {
            return true;
            //bool isValid;

            //if (!Schedule.Exists(x => x.DayScheduleDate == CurrentDate) || CurrentDate == null)
            //    isValid = false;
            //else
            //    isValid = true;

            //return isValid;
        }
    }
}
