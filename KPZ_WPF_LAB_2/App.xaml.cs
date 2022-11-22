using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using KPZ_WPF_LAB_2.Models;
using KPZ_WPF_LAB_2.NavigationViews;
using KPZ_WPF_LAB_2.View;
using KPZ_WPF_LAB_2.ViewModel;

namespace KPZ_WPF_LAB_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DataModel _model;
        public App()
        {
            _model = DataModel.Load();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            

            NavigationScheduleManager _navigationSchedule = new NavigationScheduleManager();
            
            _navigationSchedule.CurrentViewModel = new LoginViewModel(_navigationSchedule, _model);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationSchedule, _model)           
            };

            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                _model.Save();
            }
            catch(Exception)
            {
                base.OnExit(e);
                throw;
            }
        }
    }
}
