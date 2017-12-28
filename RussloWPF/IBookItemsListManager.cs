using RussloWPF.Models.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussloWPF
{
    public interface IBookItemsListManager
    {
        void RemoveItem(BookListItemViewModel item);
    }
}
