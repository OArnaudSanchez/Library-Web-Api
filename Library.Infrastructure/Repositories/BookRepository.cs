using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        
        public BookRepository(LibraryContext context)
        {
            _context = context; 
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
           return await _context.Book.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Book.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task InsertBook(Book libro)
        {
           await _context.Book.AddAsync(libro);
           await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBook(Book libro)
        {
            var currentBook = await GetBook(libro.Id);
            currentBook.Title = libro.Title;
            currentBook.ReleaseDate = libro.ReleaseDate;
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var currentBook = await GetBook(id);
            _context.Book.Remove(currentBook);
           return await _context.SaveChangesAsync() > 0;
        }
    }
}