using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IComparable<Book>
    {
        #region properties
        /// <summary>
        /// Title of the book
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Author (or authors)
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The year, this book was published
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Number of pages
        /// </summary>
        public int Pages { get; set; }

        private static IComparer<Book> Comparer { get; }

        #endregion

        #region overriding object

        public override bool Equals(object obj)
        {
            if (obj is Book) return this.Equals((Book) obj);
            return false;
        }

        public override string ToString()
        {
            return $"Book: {Author} \"{Name}\", {Year}.";
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int h = Name.GetHashCode() + Author.GetHashCode() + Pages + Year;
                return h;
            }
        }

        #endregion

        #region c-tors

        /// <summary>
        /// Initialises comparator
        /// </summary>
        static Book()
        {
            Comparer = new FullComparer();
        }

        /// <summary>
        /// c-tor
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="name">Name</param>
        /// <param name="year"Year></param>
        /// <param name="pages">number of pages</param>
        public Book(string author, string name, int year, int pages)
        {
            if(author == null || name == null) throw new ArgumentNullException();
            if(pages < 1 || year < 0) throw new ArgumentOutOfRangeException();
            Name = name;
            Author = author;
            Year = year;
            Pages = pages;
        }

        /// <summary>
        /// Default c-tor
        /// </summary>
        public Book() : this("Richter", "The best book", 2012, 5000) { }

        #endregion

        #region comparing

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <returns>true if equals</returns>
        public bool Equals(Book other)
        {
            return Comparer.Compare(this, other) == 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <returns>negative if less, 0 if equals, positive if greater</returns>
        public int CompareTo(Book other)
        {
            return Comparer.Compare(this, other);
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>true if less</returns>
        public static bool operator <(Book lhs, Book rhs)
        {
            return Comparer.Compare(lhs, rhs) < 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>true if greater</returns>
        public static bool operator >(Book lhs, Book rhs)
        {
            return Comparer.Compare(lhs, rhs) > 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>true if less or equal</returns>
        public static bool operator <=(Book lhs, Book rhs)
        {
            return Comparer.Compare(lhs, rhs) <= 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>true if less or equal</returns>
        public static bool operator >=(Book lhs, Book rhs)
        {
            return Comparer.Compare(lhs, rhs) >= 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>true if equal</returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            return Comparer.Compare(lhs, rhs) == 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>false if equal</returns>
        public static bool operator !=(Book lhs, Book rhs)
        {
            return Comparer.Compare(lhs, rhs) != 0;
        }

        #endregion
    }
}
