using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class GenderRepository : IGenderRepository
    {
        private readonly LibraryContext _context;
        public GenderRepository(LibraryContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Gender>> GetGenders()
        {
            var generos = await _context.Gender.ToListAsync();
            return generos;
        }

        public async Task<Gender> GetGender(int id)
        {
            var genero = await _context.Gender.FirstOrDefaultAsync(x=>x.Id == id);
            return genero;
        }
        public async Task InsertGender(Gender genero)
        {
            await _context.Gender.AddAsync(genero);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateGender(Gender genero)
        {
            var currentGenero = await GetGender(genero.Id);

            currentGenero.NameGender = genero.NameGender;
            
           return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteGender(int id)
        {
            var currentGenero = await GetGender(id);
            _context.Gender.Remove(currentGenero);
            return await _context.SaveChangesAsync() > 0 ;
        }
    }
}
