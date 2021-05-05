using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
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
        public bool CreateBook(Book book, Publisher publisher)
        {
            return repository.CreateBook(book, publisher);
        }
    }
}
