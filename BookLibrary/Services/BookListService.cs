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

        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="books">Collection of books</param>
        public BookListService(IEnumerable<Book> books)
        {
            if (books == null)
            {
                Books = new List<Book>();
                return;
            }
            Books = new List<Book>(books);
        }

        /// <summary>
        /// default c-tor
        /// </summary>
        public BookListService()
        {
            Books = new List<Book>();
        }

        public Book[] GetArray()
        {
            return Books.ToArray();
        }

        /// <summary>
        /// Adds book
        /// </summary>
        /// <param name="book">Book to add</param>
        public void AddBook(Book book)
        {
            if(book == null) throw new ArgumentNullException();
            if(Books.Contains(book)) throw new ArgumentException($"{book} already exists.");
            Books.Add(book);
        }

        /// <summary>
        /// Finds book
        /// </summary>
        /// <param name="predicate">Criteria to find</param>
        public Book FindBookByTag(Predicate<Book> predicate)
        {
            return Books.Find(predicate);
        }

        /// <summary>
        /// Removes book
        /// </summary>
        /// <param name="book">Book to remove</param>
        public void RemoveBook(Book book)
        {
            if (!Books.Contains(book)) throw new ArgumentException($"{book} doesn't exist.");
            Books.Remove(book);
        }

        /// <summary>
        /// Method to sort
        /// </summary>
        /// <param name="comparer">Comparer</param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            Books.Sort(comparer);
        }

        /// <summary>
        /// Method to save
        /// </summary>
        /// <param name="storage">place to save</param>
        public void Save(IBookListStorage storage)
        {
            storage.Save(Books);
        }

        /// <summary>
        /// Method to load
        /// </summary>
        /// <param name="storage">place to load from</param>
        public void Load(IBookListStorage storage)
        {
            Books = new List<Book>(storage.Load());
        }
    }
}
