using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class FullComparer : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            if (ReferenceEquals(lhs, rhs)) return 0;
            if (ReferenceEquals(lhs, null)) return 1;
            if(ReferenceEquals(rhs, null)) return -1;
            int a =  string.Compare (lhs.Name, rhs.Name, ignoreCase:true, culture: CultureInfo.CurrentCulture);
            if (a != 0) return a;
            a = string.Compare(lhs.Author, rhs.Author, ignoreCase: true, culture: CultureInfo.CurrentCulture);
            if (a != 0) return a;
            return lhs.Year - rhs.Year;
        }
    }
}
