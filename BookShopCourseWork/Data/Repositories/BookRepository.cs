using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
        public bool CreateBook(CreateBook book)
        {
            if (context.Books.Any(b => b.Title == book.Title))
            {
                return false;
            }
            else
            {
                Publisher pub = context.Publishers.FirstOrDefault(p=>p.PublisherName == book.PublisherName);
                if(pub==null)
                {
                    pub = new Publisher(){PublisherName = book.PublisherName};
                }
                Genre gen = context.Genres.FirstOrDefault(g => g.GenreName == book.GenreName);
                if(gen==null)
                {
                    gen = new Genre(){GenreName = book.GenreName};
                }
                Author au = context.Authors.FirstOrDefault(a=>a.FirstName == book.FirstName && a.LastName == book.LastName);
                if(au==null)
                {
                    au = new Author(){FirstName= book.FirstName, LastName = book.LastName};
                }
                Book b = new Book();
                b.Title = book.Title;
                b.Description = book.Description;
                b.ImgUrl = book.ImgUrl;
                b.Pages = book.Pages;
                b.PublishedOn = book.PublishedOn;
                b.Price = book.Price;
                b.Authors = new List<Author>();
                b.Authors.Add(au);
                b.Genres = new List<Genre>();
                b.Genres.Add(gen);
                b.Orders = new List<Order>();
                b.Publisher = pub;
                context.Books.Add(b);
                context.SaveChanges();
                return true;
            }
        }
        public bool EditBook(EditBook book)
        {
            Book b = context.Books.Find(book.Id);
            if (b != null)
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

        public List<Book> GetBooksByGenre(string genreName)
        {
            Genre genre = context.Genres.Where(g => g.GenreName == genreName).FirstOrDefault<Genre>(); ;
            if (genre != null)
            {
                return context.Books.Include(b => b.Genres).Where(b => b.Genres.Contains(genre)).ToList();
            }
            else
            {
                return null;
            }
        }
        public List<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }
        public List<Book> GetAllBooks()
        {
            return context.Books
                     .Select(book => new Book()
                     {
                         Id = book.Id,
                         Title = book.Title,
                         Description = book.Description,
                         Genres = book.Genres.Select(genre => genre).ToList(),
                         Price = book.Price,
                         Pages = book.Pages,
                         ImgUrl = book.ImgUrl,
                         PublishedOn = book.PublishedOn,
                         PublisherId = book.PublisherId,
                         Authors = book.Authors.Select(author => author).ToList()
                     }).ToList();
        }
        public Book GetBookById(int bookId)
        {
            return context.Books.Select(book => new Book()
                     {
                         Id = book.Id,
                         Title = book.Title,
                         Description = book.Description,
                         Genres = book.Genres.Select(genre => genre).ToList(),
                         Publisher = context.Publishers.FirstOrDefault(p=> p.Id == book.PublisherId),
                         Price = book.Price,
                         Pages = book.Pages,
                         ImgUrl = book.ImgUrl,
                         PublishedOn = book.PublishedOn,
                         PublisherId = book.PublisherId,
                         Authors = book.Authors.Select(author => author).ToList()
                     }).FirstOrDefault(b => b.Id == bookId);
        }
    }
}
