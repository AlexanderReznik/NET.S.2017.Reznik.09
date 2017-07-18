using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Base
{
    public interface IBookListStorage
    {
        void Save(List<Book> list);
        void Load(out List<Book> list);
    }
}
