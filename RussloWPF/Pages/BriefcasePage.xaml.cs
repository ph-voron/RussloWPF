using Newtonsoft.Json;
using RussloWPF.Data;
using RussloWPF.Models;
using RussloWPF.Models.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// Логика взаимодействия для BriefcasePage.xaml
    /// </summary>
    public partial class BriefcasePage : Page, IBookItemsListManager
    {
        //
        private ObservableCollection<BookListItemViewModel> DataSource = new ObservableCollection<BookListItemViewModel>();
        private List<BookListItemViewModel> SearchRequestResult = new List<BookListItemViewModel>();
        //
        public BriefcasePage()
        {
            InitializeComponent();
            //
            ApplySearch(null);
            PopulateNextPage();
        }
        //
        private void ApplySearch(string text)
        {
            SearchRequestResult = AppData.Inst()
                .GetBooksList()
                .Select(x => new BookListItemViewModel(x, this))
                .ToList() ;
            if (text != null && text.Length > 0)
            { 
                text = text.ToLower();
                SearchRequestResult = SearchRequestResult
                    .Where(x => 
                    x.Title.ToLower().Contains(text) ||
                    x.Author.ToLower().Contains(text) ||
                    x.Description.ToLower().Contains(text))
                    .ToList();
            }
        }
        //
        private Task SearchAsync(string search)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(300);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    SearchRequestResult.Clear();
                    DataSource.Clear();
                }));
                ApplySearch(search);
                PopulateNextPage();
            });
        }
        //
        private void PopulateNextPage()
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                foreach (var item in SearchRequestResult.Skip(DataSource.Count).Take(10))
                {
                    DataSource.Add(item);
                }
            }));
        }
        //
        public async void BeginNewSearch(string search)
        {
            var parent = (MainWindow)Window.GetWindow(this);
            parent.ShowProgressDialog(true);
            await SearchAsync(search);
            parent.ShowProgressDialog(false);
        }
        //
        private async void BooksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0) return;
            var parent = (IMainWindow)Window.GetWindow(this);
            var item = (BookListItemViewModel)e.AddedItems[0];
            parent.ShowProgressDialog(true);
            await AppData.Inst().PrepareReaderContentAsync(item);
            parent.ShowProgressDialog(false);
            parent.NavigateToPage(PageTypesEnum.readerPage);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BooksList.ItemsSource = DataSource;
        }

        private void BooksList_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollHeight = e.VerticalOffset + e.ViewportHeight;
            if(e.VerticalOffset > 0 && scrollHeight >= e.ExtentHeight-100)
            {
                PopulateNextPage();
            }
        }

        private void SearchSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            BeginNewSearch(SearchTextField.Text);
        }

        private void SearchTextField_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                BeginNewSearch(SearchTextField.Text);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sndrButton = (Button)sender;
            var model = (BookListItemViewModel)sndrButton.DataContext;
            //
            if(model != null) Debug.WriteLine("Button_Click: author = {0}, title = {1}, description = {2}", 
                model.Author, model.Title, model.Description);
        }

        public void RemoveItem(BookListItemViewModel item)
        {
            DataSource.Remove(item);
        }
    }
}
