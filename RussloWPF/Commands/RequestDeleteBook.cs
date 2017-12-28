using RussloWPF.Models.MVVM;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RussloWPF.Commands
{
    public class RequestDeleteBook : ICommand
    {
        private IBookItemsListManager Parent = null;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter != null && parameter.GetType() == typeof(BookListItemViewModel))
            {
                var model = (BookListItemViewModel)parameter;
                Parent?.RemoveItem(model);
            }
        }

        public RequestDeleteBook(IBookItemsListManager parent)
        {
            Parent = parent;
        }

    }
}
