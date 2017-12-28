using RussloWPF.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RussloWPF.Models.MVVM
{
    public class BookListItemViewModel : INotifyPropertyChanged
    {
        private BookListItem DataItem = null;
        private ICommand _deleteItemCommand = new RequestDeleteBook();
        public event PropertyChangedEventHandler PropertyChanged;
        public BookListItemViewModel() { }
        public BookListItemViewModel(BookListItem item)
        {
            DataItem = item;
        }
        //
        public string Title
        {
            get { return DataItem.Title; }
            set { DataItem.Title = value; }
        }
        //
        public string Author
        {
            get { return DataItem.Author; }
            set { DataItem.Author = value; }
        }
        //
        public string Description
        {
            get { return DataItem.Description; }
            set { DataItem.Description = value; }
        }
        //
        public ICommand DeleteItemCommand { get { return _deleteItemCommand; } }
    }
}
