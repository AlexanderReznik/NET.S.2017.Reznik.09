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
        /// Indexer
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Book i in list</returns>
        public Book this[int i] => Books[i];

        /// <summary>
        /// Size
        /// </summary>
        /// <returns>Size of a collection</returns>
        public int Size() => Books.Count;

        public BookListService(List<Book> books)
        {
            Books = new List<Book>();
        }

        public BookListService() : this(new List<Book>()) { }

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
            storage.Load(out _books);
        }
    }
}
