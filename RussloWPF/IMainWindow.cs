using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussloWPF
{
    public interface IMainWindow
    {
        void NavigateToPage(PageTypesEnum page);
        void NavigateBack();
        void ShowProgressDialog(bool value);
    }
}
