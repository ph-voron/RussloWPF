using Newtonsoft.Json;
using RussloWPF.Models;
using RussloWPF.Models.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RussloWPF.Data
{
    /// <summary>
    /// Всякие асинхронные обработки-заглушки
    /// </summary>
    public class AppData
    {
        private static readonly AppData _instance = new AppData();
        //
        public static AppData Inst()
        {
            return _instance;
        }
        //
        private List<BookListItem> BooksListData = null;
        private string ReaderContentHtml = "";
        //
        private AppData()
        {
            BooksListData = JsonConvert.DeserializeObject<List<BookListItem>>(Properties.Resources.BooksList);
        }
        //
        public List<BookListItem> GetBooksList()
        {
            return BooksListData.Select(x => (BookListItem)x.Clone()).ToList();
        }
        //
        public Task<bool> AuthorizeAsync(string login, string password)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return true;
            });
        }
        //
        public Task PrepareReaderContentAsync(BookListItemViewModel bookItem)
        {
            return Task.Run(() =>
            {
                ReaderContentHtml = string.Format(Properties.Resources.ReaderStub, bookItem.Title, bookItem.Author, bookItem.Description);
                Thread.Sleep(1000);
            });
        }
        //
        public Task<string> GetReaderContentAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(500);
                return ReaderContentHtml;
            });
        }
    }
}
