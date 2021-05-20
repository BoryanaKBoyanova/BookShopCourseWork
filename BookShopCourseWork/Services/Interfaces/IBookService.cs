using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Services.Interfaces
{
    public interface IBookService
    {
        public bool CreateBook(Book book, Publisher publisher, Author author);

        public bool DeleteBook(DeleteBook book);

        public List<Author> GetAuthors();

        public bool EditBook(EditBook book);
        public List<Book> GetBooksByGenre(Genre genre);

        public List<Book> GetAllBooks();
    }
}
