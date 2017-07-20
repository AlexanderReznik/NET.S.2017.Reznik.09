using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Base
{
    public interface IBookListStorage
    {
        void Save(IEnumerable<Book> list);
        IEnumerable<Book> Load();
    }
}
