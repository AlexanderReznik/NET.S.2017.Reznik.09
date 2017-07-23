using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BookLibrary.Base;

namespace BookLibrary.Storages
{
    public class XMLSerializibleBookListStorage : IBookListStorage
    {
        private readonly string _fileName;

        private string FileName => _fileName;

        public XMLSerializibleBookListStorage(string filename)
        {
            _fileName = filename;
        }

        /// <summary>
        /// Method to deserialize list of books from binary file
        /// </summary>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> Load()
        {
            if (!File.Exists(FileName)) throw new FileNotFoundException();
            using (FileStream stream = new FileStream(FileName, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                List<Book> list = (List<Book>)serializer.Deserialize(stream);

                return list;
            }
        }

        /// <summary>
        /// A method to save a list of books to binary file
        /// </summary>
        /// <param name="list">Coolection to save</param>
        public void Save(IEnumerable<Book> list)
        {
            if (list == null)
                throw new ArgumentNullException();
            using (FileStream stream = new FileStream(FileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, list);
            }
        }
    }
}
