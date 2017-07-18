using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Base
{
    public interface IBookService
    {
        void AddBook(Book book);
        void RemoveBook(Book book);
        Book FindBookByTag(Predicate<Book> predicate);
        void SortBooksByTag(IComparer<Book> comparer);
    }
}
