using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using KPZ_WPF_LAB_2.Models;

namespace KPZ_WPF_LAB_2.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public DataModel DataModel { get; set; }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
