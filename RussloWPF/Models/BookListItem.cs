using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussloWPF.Models
{
    public class BookListItem: ICloneable
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public object Clone()
        {
            return new BookListItem()
            {
                Author = Author,
                Description = Description,
                Title = Title
            };
        }
    }
}
