using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Data.Repositories;

namespace BookShopCourseWork.Services
{
    public class BookService : IBookService
    {
        private IBookRepository repository { get; set; }
        public BookService()
        {
            repository = new BookRepository();
        }
        public bool CreateBook(CreateBook book)
        {
            return repository.CreateBook(book);
        }
        public List<Author> GetAuthors()
        {
            return repository.GetAuthors();
        }
        public bool EditBook(EditBook book)
        {
            return repository.EditBook(book);
        }
        public Book GetBookById(int bookId)
        {
            return repository.GetBookById(bookId);
        }
        public List<Book> GetBooksByGenre(Genre genre)
        {
            return repository.GetBooksByGenre(genre.GenreName);
        }
        public List<Book> GetAllBooks()
        {
            return repository.GetAllBooks();
        }
    }
}
