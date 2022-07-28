using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatClientHome
{
    class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        Action _action;
        Action<object> _actionWithParam;
        Func<bool> _canExecute;
        public Command(Action action, Func<bool> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public Command(Action<object> action, Func<bool> canExecute = null)
        {
            _actionWithParam = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            if (_action != null)
                _action();
            if (_actionWithParam != null)
                _actionWithParam(parameter);
        }
    }
}
