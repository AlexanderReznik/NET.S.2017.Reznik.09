using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Base;

namespace BookLibrary.Storages
{
    public class BinarySerializibleBookListStorage : IBookListStorage
    {
        private readonly string _fileName;

        private string FileName => _fileName;

        public BinarySerializibleBookListStorage(string filename)
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
                BinaryFormatter formatter = new BinaryFormatter();
                List<Book> list = (List < Book >)formatter.Deserialize(stream);

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
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, list);
            }
        }
    }
}
