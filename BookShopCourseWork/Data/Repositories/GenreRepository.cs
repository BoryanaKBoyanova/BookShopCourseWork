using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.GenreController;

namespace BookShopCourseWork.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext context;
        public GenreRepository()
        {
            context = new ApplicationDbContext();
        }
        public bool AddGenre(Genre genre)
        {
            if(context.Genres.Any(g => g.GenreName == genre.GenreName))
            {
                return false;
            }
            else
            {
                context.Genres.Add(genre);
                context.SaveChanges();
                return true;
            }

        }
        public bool DeleteGenre(DeleteGenre genre)
        {
            Genre g = context.Genres.Find(genre.GenreId);
            if(g!=null)
            {
                context.Genres.Remove(g);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddGenreBook(AddGenreBook addGenreBook)
        {
            Genre g = context.Genres.Find(addGenreBook.GenreId);
            Book b = context.Books.Find(addGenreBook.BookId);
            if(g == null || b == null)
            {
                return false;
            }
            else
            {
                GenreBook gb = new GenreBook();
                gb.GenreId = g.Id;
                gb.BookId = b.Id;
                context.GenreBook.Add(gb);
                context.SaveChanges();
                return true;
            }
        }
    }
}