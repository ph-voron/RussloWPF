using RussloWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RussloWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var parent = (IMainWindow)Window.GetWindow(this);
            parent.ShowProgressDialog(true);
            await AppData.Inst().AuthorizeAsync(Login.Text, Password.Password);
            parent.ShowProgressDialog(false);
            parent.NavigateToPage(PageTypesEnum.briefcasePage);
        }
    }
}
