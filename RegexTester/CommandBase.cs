using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace V2.Elements.Paramers
{
    public class CommandBase : ICommand
    {
        #region ICommand realization

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion

        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public CommandBase(Action<object> execute)
            : this(execute, null)
        { }

        public CommandBase(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Command argument can not be null!");

            _execute = execute;
            _canExecute = canExecute;
        }
    }
}
