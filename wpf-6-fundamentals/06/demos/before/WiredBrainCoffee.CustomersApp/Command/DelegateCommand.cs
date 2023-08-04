using System;
using System.Windows.Input;

namespace WiredBrainCoffee.CustomersApp.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> myAction;
        private readonly Func<object?, bool>? myCanExecute;
        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<object?> action, Func<object?, bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(action);
            myAction = action;
            myCanExecute = canExecute;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter)
        {
            if (myCanExecute == null)
            {
                return true;
            }
            return myCanExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            myAction(parameter);
        }
    }
}
