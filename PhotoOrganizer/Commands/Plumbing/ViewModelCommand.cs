using System;
using System.Windows.Input;

namespace PhotoOrganizer.Commands.Plumbing
{
    public abstract class ViewModelCommand : ICommand
    {
        public ParameterResolver ParameterResolver { get; set; }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        protected ViewModelCommand()
        {
            ParameterResolver = new ParameterResolver();
        }
    }
}