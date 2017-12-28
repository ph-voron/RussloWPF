using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RussloWPF.Commands
{
    public class NavigateToBriecaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public event Action OnNavigate;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OnNavigate?.Invoke();
        }
    }
}
