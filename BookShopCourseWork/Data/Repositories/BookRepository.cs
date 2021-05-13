using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.BookController;

namespace BookShopCourseWork.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext context;
        public BookRepository()
        {
            context = new ApplicationDbContext();
        }
        public bool CreateBook(Book book, Publisher publisher)
        {
            if(context.Books.Any(b => b.Title == book.Title))
            {
                return false;
            }
            else
            {
                if(!context.Publishers.Any(p => p.PublisherName == publisher.PublisherName))
                {
                    context.Publishers.Add(publisher);
 
                }
                book.Publisher = publisher;
                context.Books.Add(book);
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteBook(DeleteBook book)
        {
            Book b = context.Books.Find(book.BookId);
            if(b!=null)
            {
                context.Books.Remove(b);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool EditBook(EditBook book)
        {
            Book b = context.Books.Find(book.Id);
            if(b!=null)
            {
                b.Title = book.Title;
                b.Description = book.Description;
                b.Price = book.Price;
                b.ImgUrl = book.ImgUrl;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
