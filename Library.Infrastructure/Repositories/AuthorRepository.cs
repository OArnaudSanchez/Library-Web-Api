using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _dbContext;
        public AuthorRepository(LibraryContext context)
        {
            _dbContext = context;
        }
        
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            var autores = await _dbContext.Author.ToListAsync();
            return autores;
        }

        public async Task<Author> GetAuthor(int id)
        {
            var autor = await _dbContext.Author.FirstOrDefaultAsync(x=>x.Id == id);
            return autor;
        }

        public async Task InsertAuthor(Author autor)
        {
             await _dbContext.AddAsync(autor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAuthor(Author autor)
        {
            var currentAutor = await GetAuthor(autor.Id);
            currentAutor.Name = autor.Name;
            currentAutor.LastName = autor.LastName;
            currentAutor.BirthDate = autor.BirthDate;
            currentAutor.AuthorGender = autor.AuthorGender;

            int totalRowsAfected = await _dbContext.SaveChangesAsync();

            return  totalRowsAfected > 0;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var currentAutor = await GetAuthor(id);
            _dbContext.Author.Remove(currentAutor);

            int totalRowsAfected = await _dbContext.SaveChangesAsync();

            return  totalRowsAfected > 0;
        }
    }
}