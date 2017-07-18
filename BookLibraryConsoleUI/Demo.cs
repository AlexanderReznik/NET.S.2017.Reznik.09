using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

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
            for (int i = 0; i < service.Size(); i++)
                Console.WriteLine(service[i]);

            Book b = new Book("A. C. Doyle", "Sherlok Holmes", 1980, 550);
            Console.WriteLine($"{service[0]} == {b}{service[0] == b}");
            Console.WriteLine($"{service[1]} == {b}{service[1] == b}");

            Console.WriteLine(service.FindBookByTag(x => x.Name == "R. Zelazny"));

            service.SortBooksByTag(new FullComparer());
            Console.WriteLine("Sorted Library:");
            for (int i = 0; i < service.Size(); i++)
                Console.WriteLine(service[i]);

            BinaryBookListStorage s = new BinaryBookListStorage("storage.txt");
            service.Save(s);

            BookListService otherBookListService = new BookListService();
            otherBookListService.Load(s);

            Console.WriteLine();
            Console.WriteLine("Loaded Library:");
            for (int i = 0; i < otherBookListService.Size(); i++)
                Console.WriteLine(otherBookListService[i]);

            Console.ReadKey();
        }
    }
}
