using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IAuthorRepository
    {
         Task<IEnumerable<Author>> GetAuthors();
         Task<Author> GetAuthor(int id);
         Task InsertAuthor(Author libro);
         Task<bool> UpdateAuthor(Author libro);
         Task<bool> DeleteAuthor(int id);
    }
}