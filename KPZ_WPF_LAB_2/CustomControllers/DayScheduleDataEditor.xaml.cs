using KPZ_WPF_LAB_2.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KPZ_WPF_LAB_2.CustomControllers
{
    /// <summary>
    /// Interaction logic for DayScheduleDataEditor.xaml
    /// </summary>
    public partial class DayScheduleDataEditor : UserControl
    {
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(DayScheduleEditorViewModel), typeof(DayScheduleDataEditor));

        public static readonly DependencyProperty CreateCommandProperty =
           DependencyProperty.Register("CreateCommand", typeof(ICommand), typeof(DayScheduleDataEditor));


        public DayScheduleDataEditor()
        {
            InitializeComponent();
        }

        public ICommand CreateCommand
        {
            get { return (ICommand)GetValue(CreateCommandProperty); }
            set { SetValue(CreateCommandProperty, value); }
        }

        public DayScheduleEditorViewModel Item
        {
            get { return (DayScheduleEditorViewModel)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }
    }
}
