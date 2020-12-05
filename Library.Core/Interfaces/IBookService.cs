using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBookService
    {
         Task<IEnumerable<Book>> GetBooks();
         Task<Book> GetBook(int id);
         Task InsertBook(Book libro);
         Task<bool> UpdateBook(Book libro);
         Task<bool> DeleteBook(int id);
    }
}