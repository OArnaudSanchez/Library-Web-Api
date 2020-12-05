using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable> GetAuthors();
         Task<Author> GetAuthor(int id);
         Task InsertAuthor(Author author);
         Task<bool> UpdateAuthor(Author author);
         Task<bool> DeleteAuthor(int id);
    }
}