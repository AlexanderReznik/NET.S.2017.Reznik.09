using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Base;

namespace BookLibrary
{
    public class BinaryBookListStorage : IBookListStorage
    {
        private readonly string _fileName;

        private string FileName => _fileName;

        public BinaryBookListStorage(string filename)
        {
            _fileName = filename;
        }

        /// <summary>
        /// Method to load a list of books from binary file
        /// </summary>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> Load()
        {
            if(!File.Exists(FileName)) throw new FileNotFoundException();
            using (BinaryReader reader = new BinaryReader(File.OpenRead(FileName)))
            {
                List<Book> list = new List<Book>();

                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    string author = reader.ReadString();
                    string name = reader.ReadString();
                    int year = reader.ReadInt32();
                    int pages = reader.ReadInt32();

                    Book b = new Book(author, name, year, pages);

                    if(!list.Contains(b)) list.Add(b);
                }
                return list;
            }
        }

        /// <summary>
        /// A method to save a list of books to binary file
        /// </summary>
        /// <param name="list">Coolection to save</param>
        public void Save(IEnumerable<Book> list)
        {
            if(list == null)
                throw new ArgumentNullException();
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(FileName)))
            {
                foreach (Book b in list)
                {
                    writer.Write(b.Author);
                    writer.Write(b.Name);
                    writer.Write(b.Year);
                    writer.Write(b.Pages);
                }
            }
        }
    }
}
