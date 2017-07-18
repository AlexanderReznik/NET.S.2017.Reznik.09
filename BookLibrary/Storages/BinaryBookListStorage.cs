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

        public void Load(out List<Book> list)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(FileName)))
            {
                list = new List<Book>();

                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    string author = reader.ReadString();
                    string name = reader.ReadString();
                    int year = reader.ReadInt32();
                    int pages = reader.ReadInt32();

                    Book b = new Book(author, name, year, pages);

                    if(!list.Contains(b)) list.Add(b);
                }
            }
        }

        public void Save(List<Book> list)
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
