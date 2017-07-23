using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    [Serializable]
    public class Book : IComparable<Book>, IComparable, IEquatable<Book>
    {
        #region properties

        private string _name;
        private string _author;
        private int _year;
        private int _pages;

        /// <summary>
        /// Title of the book
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException();
                _name = value;
            }
        }

        /// <summary>
        /// Author (or authors)
        /// </summary>
        public string Author
        {
            get { return _author; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _author = value;
            }
        }

        /// <summary>
        /// The year, this book was published
        /// </summary>
        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                _year = value;
            }
        }

        /// <summary>
        /// Number of pages
        /// </summary>
        public int Pages
        {
            get { return _pages; }
            set
            {
                if (value < 1)
                    throw new ArgumentException();
                _pages = value;
            }
        }

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
        /// c-tor
        /// </summary>
        /// <param name="author">Author</param>
        /// <param name="name">Name</param>
        /// <param name="year">Year</param>
        /// <param name="pages">number of pages</param>
        public Book(string author, string name, int year, int pages)
        { 
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
            return Compare(this, other) == 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <returns>negative if less, 0 if equals, positive if greater</returns>
        public int CompareTo(Book other)
        {
            return Compare(this, other);
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <returns>negative if less, 0 if equals, positive if greater</returns>
        public int CompareTo(Object other)
        {
            if(!(other is Book)) throw new ArgumentException("Incorrect comparision");
            return Compare(this, (Book)other);
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>true if equal</returns>
        public static bool operator ==(Book lhs, Book rhs)
        {
            return Compare(lhs, rhs) == 0;
        }

        /// <summary>
        /// Method to compare
        /// </summary>
        /// <param name="lhs">One book</param>
        /// <param name="rhs">Another book</param>
        /// <returns>false if equal</returns>
        public static bool operator !=(Book lhs, Book rhs)
        {
            return Compare(lhs, rhs) != 0;
        }

        private static int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return 0;
            if (ReferenceEquals(lhs, null)) return 1;
            if (ReferenceEquals(rhs, null)) return -1;
            return string.Compare(lhs.Name, rhs.Name, ignoreCase: true, culture: CultureInfo.CurrentCulture);
        }

        #endregion
    }
}
