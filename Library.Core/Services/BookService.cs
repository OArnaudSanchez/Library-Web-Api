using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Core.Interfaces;

namespace Library.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenderRepository _genderRepository;


        public BookService(IBookRepository bookRepository, IAuthorRepository author, IGenderRepository gender)
        {
            _bookRepository = bookRepository;
            _authorRepository = author;
            _genderRepository = gender;
        }
        
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _bookRepository.GetBook(id);
        }

        public async Task InsertBook(Book libro)
        {
            //Verificar si existe el autor, para poder insertar el libro
            var bookAutor = await _authorRepository.GetAuthor(libro.Author);

            if(bookAutor == null)
            {
                throw new Exception("El Autor no Existe");
            }

            //Verificar si el genero existe
            var genderBook = await _genderRepository.GetGender(libro.Gender);
            if(genderBook == null)
            {
                throw new Exception("El Genero no existe");
            }

            libro.Id = 0;
            await _bookRepository.InsertBook(libro);
        }

        public async Task<bool> UpdateBook(Book libro)
        {
           var currentLibro = await _bookRepository.GetBook(libro.Id);
           if(currentLibro == null)
           {
               throw new Exception("El libro no existe");
           }

           return await _bookRepository.UpdateBook(libro) ? true : false;
        }
        public async Task<bool> DeleteBook(int id)
        {
            var currentLibro = await _bookRepository.GetBook(id);
           if(currentLibro == null)
           {
               throw new Exception("El libro no existe");
           }

           return await _bookRepository.DeleteBook(id) ? true : false;
        }
    }
}