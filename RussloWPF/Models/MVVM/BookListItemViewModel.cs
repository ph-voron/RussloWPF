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
    /// <summary>
    /// ViewModel на основе BookListItem, для передачи ее во View - элемент списка listView.
    /// Содержит поле Command, для того, чтобы привязать действие к триггеру нажатия на кнопку удаления во View
    /// </summary>
    public class BookListItemViewModel : INotifyPropertyChanged
    {
        private BookListItem DataItem = null;
        private ICommand _deleteItemCommand = null;
        public event PropertyChangedEventHandler PropertyChanged;
        public BookListItemViewModel() { }
        public BookListItemViewModel(BookListItem item, IBookItemsListManager parent)
        {
            DataItem = item;
            _deleteItemCommand = new RequestDeleteBook(parent);
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
