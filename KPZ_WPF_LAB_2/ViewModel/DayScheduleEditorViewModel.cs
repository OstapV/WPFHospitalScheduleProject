using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KPZ_WPF_LAB_2.ViewModel
{
    public class DayScheduleEditorViewModel : ViewModelBase
    {
        private TimeSpan _startWorkDay;
        private TimeSpan _endWorkDay;
        private TimeSpan _interval;

        public TimeSpan StartWorkDay 
        { 
            get => _startWorkDay; 
            set {
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

        public TimeSpan Interval
        {
            get => _interval;
            set
            {
                _interval = value;
                OnPropertyChanged(nameof(Interval));
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
