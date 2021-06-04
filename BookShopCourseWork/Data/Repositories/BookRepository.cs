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
        public bool CreateBook(Book book, Publisher publisher, Author author, Genre genre)
        {
            if (context.Books.Any(b => b.Title == book.Title))
            {
                return false;
            }
            else
            {
                Publisher pub = context.Publishers.FirstOrDefault(p=>p.PublisherName == publisher.PublisherName);
                if(pub==null)
                {
                    pub = publisher;
                }
                Genre gen = context.Genres.FirstOrDefault(g => g.GenreName == genre.GenreName);
                if(gen==null)
                {
                    gen = genre;
                }
                Author au = context.Authors.FirstOrDefault(a=>a.FirstName == author.FirstName && a.LastName == author.LastName);
                if(au==null)
                {
                    au = author;
                }
                book.Authors = new List<Author>();
                book.Authors.Add(au);
                book.Genres = new List<Genre>();
                book.Genres.Add(gen);
                book.Orders = new List<Order>();
                book.Publisher = pub;
                context.Books.Add(book);
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
