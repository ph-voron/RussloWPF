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
                Debug.WriteLine("RequestDeleteBook Command: author = {0}, title = {1}, description = {2}",
                model.Author, model.Title, model.Description);
            }
        }

    }
}
