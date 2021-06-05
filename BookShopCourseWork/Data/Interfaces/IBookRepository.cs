using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Data.Interfaces
{
    interface IBookRepository
    {
        public bool CreateBook(CreateBook book);

        public bool EditBook(EditBook book);

        public List<Book> GetBooksByGenre(string genreName);

        public List<Author> GetAuthors();
        public List<Book> GetAllBooks();
        public Book GetBookById(int bookId);

    }
}
