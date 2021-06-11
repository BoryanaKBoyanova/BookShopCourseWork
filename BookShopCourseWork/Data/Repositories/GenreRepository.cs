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
        public List<Genre> GetAllGenres()
        {
            return context.Genres.ToList();
        }
        public bool AddGenre(AddGenre genre)
        {
            if(context.Genres.Any(g => g.GenreName == genre.GenreName))
            {
                return false;
            }
            else
            {
                context.Genres.Add(new Genre(){GenreName = genre.GenreName});
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
        public bool UpdateGenreBook(UpdateGenreBook genreBook)
        {
            Genre g = context.Genres.Find(genreBook.GenreId);
            Book b = context.Books.Find(genreBook.BookId);
            if(g != null && b != null)
            {
                context.Entry(b).Collection("Genres").Load();
                if(genreBook.Operation=="addGenre")
                {
                    b.Genres.Add(g);
                    context.SaveChanges();
                    return true;
                }
                else if(genreBook.Operation=="removeGenre")
                {
                    if(b.Genres.Contains(g))
                    {
                        b.Genres.Remove(g);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}