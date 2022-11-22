using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KPZ_WPF_LAB_2.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) => true;
        
        public abstract void Execute(object parameter);

        protected void OnExecuteChanged(object parameter)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
       
    }
}
