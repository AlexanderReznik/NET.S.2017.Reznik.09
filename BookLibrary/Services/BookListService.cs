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

        private readonly ILogger logger;

        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="books">Collection of books</param>
        /// /// <param name="logger">Logger to log</param>
        public BookListService(IEnumerable<Book> books, ILogger log = null)
        {
            Books = books == null ? new List<Book>() : new List<Book>(books);

            logger = log == null ? new NLogger() : log;
        }

        /// <summary>
        /// default c-tor
        /// </summary>
        public BookListService()
        {
            Books = new List<Book>();
            logger = new NLogger();
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
            if (book == null)
            {
                logger.Debug("Exception in adding");
                throw new ArgumentNullException();
            }
            if (Books.Contains(book))
            {
                logger.Debug("Exception in adding");
                throw new ArgumentException($"{book} already exists.");
            }
            Books.Add(book);
            logger.Debug($"Book {book} added");
        }

        /// <summary>
        /// Finds book
        /// </summary>
        /// <param name="predicate">Criteria to find</param>
        public Book FindBookByTag(Predicate<Book> predicate)
        {
            logger.Debug("Finding book");
            return Books.Find(predicate);
        }

        /// <summary>
        /// Removes book
        /// </summary>
        /// <param name="book">Book to remove</param>
        public void RemoveBook(Book book)
        {
            if (!Books.Contains(book)) throw new ArgumentException($"{book} doesn't exist.");
            logger.Debug("Removing book");
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
            logger.Debug("Saving books");
        }

        /// <summary>
        /// Method to load
        /// </summary>
        /// <param name="storage">place to load from</param>
        public void Load(IBookListStorage storage)
        {
            logger.Debug("Loading book");
            Books = new List<Book>(storage.Load());
        }
    }
}
