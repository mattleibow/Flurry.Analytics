using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PortableClassLibrary
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _executeMethod;

        public DelegateCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            if (_executeMethod != null)
            {
                _executeMethod();
            }
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
