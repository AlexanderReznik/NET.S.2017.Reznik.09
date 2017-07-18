using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Base;

namespace BookLibrary
{
    public class BookListService : IBookService
    {
        private List<Book> _books;
        private List<Book> Books { get { return _books; } set { _books = value; }}

        public Book this[int i] => Books[i];

        public int Size() => Books.Count;

        public BookListService(List<Book> books)
        {
            Books = new List<Book>();
        }

        public BookListService() : this(new List<Book>()) { }

        public void AddBook(Book book)
        {
            if(book == null) throw new ArgumentNullException();
            if(Books.Contains(book)) throw new ArgumentException($"{book} already exists.");
            Books.Add(book);
        }

        public Book FindBookByTag(Predicate<Book> predicate)
        {
            return Books.Find(predicate);
        }

        public void RemoveBook(Book book)
        {
            if (!Books.Contains(book)) throw new ArgumentException($"{book} doesn't exist.");
            Books.Remove(book);
        }

        public void SortBooksByTag(IComparer<Book> comparer)
        {
            Books.Sort(comparer);
        }

        public void Save(IBookListStorage storage)
        {
            storage.Save(Books);
        }

        public void Load(IBookListStorage storage)
        {
            storage.Load(out _books);
        }
    }
}
