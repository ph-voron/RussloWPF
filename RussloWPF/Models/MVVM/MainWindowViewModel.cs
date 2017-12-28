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
    /// ViewModel главного окна. Содержит комманды (ICommand) для связи с View - панель навигации, кнопка "назад" и т.д.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IMainWindow Parent = null;
        private NavigateToBriecaseCommand _navigateToBriecaseCommand = null;
        private NavigateToLoginPageCommand _navigateToLoginPageCommand = null;
        public event PropertyChangedEventHandler PropertyChanged;
        //
        public MainWindowViewModel(IMainWindow parent)
        {
            Parent = parent;
            _navigateToBriecaseCommand = new NavigateToBriecaseCommand();
            _navigateToBriecaseCommand.OnNavigate += () => parent.NavigateToPage(PageTypesEnum.briefcasePage);
            _navigateToLoginPageCommand = new NavigateToLoginPageCommand();
            _navigateToLoginPageCommand.OnNavigate += () => parent.NavigateToPage(PageTypesEnum.loginPage);
        }
        //
        public ICommand NavigateToBriecaseCommand { get { return _navigateToBriecaseCommand; } }
        public ICommand NavigateToLoginPageCommand { get { return _navigateToLoginPageCommand; } }
    }
}
