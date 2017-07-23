using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;
using BookLibrary.Storages;

namespace BookLibraryConsoleUI
{
    class Demo
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService();
            service.AddBook(new Book("A. C. Doyle", "Sherlok Holmes", 1980, 550));
            service.AddBook(new Book("A. Lindgren", "Malysh & Carlson", 1960, 250));
            service.AddBook(new Book("J. K. Rowling", "Harry Potter", 1997, 750));
            service.AddBook(new Book("R. Zelazny", "The Chronicles of Amber", 1970, 550));
            try
            {
                service.AddBook(new Book("A. C. Doyle", "Sherlok Holmes", 1980, 550));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Library:");
            Show(service);

            Book b = new Book("A. C. Doyle", "Sherlok Holmes", 1980, 550);
            Book c = new Book("A. C. Doyle", "Sherlok Holmes", 1980, 550);
            Book d = new Book("A. C. Doyle", "The Lost World", 1980, 550);
            Console.WriteLine($"{b} == {c}{b == c}");
            Console.WriteLine($"{b} == {d}{b == d}");

            Console.WriteLine(service.FindBookByTag(x => x.Name == "R. Zelazny"));



            service.SortBooksByTag(new NameComparer());
            Console.WriteLine("Sorted Library:");
            Show(service);

            BinaryBookListStorage s = new BinaryBookListStorage("storage.txt");
            service.Save(s);

            BookListService otherBookListService = new BookListService();
            otherBookListService.Load(s);

            Console.WriteLine();
            Console.WriteLine("Loaded Library from binary:");
            Show(otherBookListService);

            BinarySerializibleBookListStorage serialize = new BinarySerializibleBookListStorage("SerializedStorage.txt");
            service.Save(serialize);

            BookListService serializedBookListService = new BookListService();
            serializedBookListService.Load(serialize);

            Console.WriteLine();
            Console.WriteLine("Loaded Library from binary with serialization:");
            Show(serializedBookListService);

            XMLSerializibleBookListStorage xml = new XMLSerializibleBookListStorage("SerializedStorage.txt");
            service.Save(xml);

            BookListService xmlBookListService = new BookListService();
            xmlBookListService.Load(xml);

            Console.WriteLine();
            Console.WriteLine("Loaded Library from xml with serialization:");
            Show(xmlBookListService);

            Console.ReadKey();
        }

        private static void Show(BookListService serv)
        {
            var arr = serv.GetArray();
            foreach (var book in arr)
            {
                Console.WriteLine(book);
            }
        }
    }

    public class NameComparer : IComparer<Book>
    {
        public int Compare(Book lhs, Book rhs)
        {
            if (lhs == null || rhs == null)
                throw new ArgumentNullException();

            return string.CompareOrdinal(lhs.Name, rhs.Name);
        }
    }
}
