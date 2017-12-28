using CefSharp;
using RussloWPF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для ReaderCEFPage.xaml
    /// </summary>
    public partial class ReaderCEFPage : Page
    {
        public ReaderCEFPage()
        {
            InitializeComponent();
            Browser.BrowserSettings.DefaultEncoding = "utf-8";
        }

        private async void ChromiumWebBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            var parent = (IMainWindow)Window.GetWindow(this);
            parent.ShowProgressDialog(true);
            var content = await AppData.Inst().GetReaderContentAsync();
            Browser.LoadHtml(content, "http://stub", Encoding.Unicode);
            parent.ShowProgressDialog(false);
        }
    }
}
