using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces;

namespace Library.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository autorRepository)
        {
            _authorRepository = autorRepository;
        }

        public async Task<IEnumerable> GetAuthors()
        {
            return await _authorRepository.GetAuthors();
        }

        public async Task<Author> GetAuthor(int id)
        {   
            return await _authorRepository.GetAuthor(id);
        }

        public async Task InsertAuthor(Author autor)
        {
     
            //Author Validations
            autor.Id = 0;

            if(autor.BirthDate < DateTime.Now)
            {
                await _authorRepository.InsertAuthor(autor);
            }
            else
            {
                throw new Exception("Invalid Date");
            }
        }

        public async Task<bool> UpdateAuthor(Author autor)
        {
            var currentAuthor = await _authorRepository.GetAuthor(autor.Id);

            if(currentAuthor == null)
            {
                throw new Exception("El autor no existe");
            }
        
            bool result = await _authorRepository.UpdateAuthor(autor);
            return result;
        }
        public async Task<bool> DeleteAuthor(int id)
        {
            var currentAuthor = await _authorRepository.GetAuthor(id);
            if(currentAuthor == null)
            {
                throw new Exception("El autor no existe");
            }

            return await _authorRepository.DeleteAuthor(id) ? true : false;
        }
    }
}
