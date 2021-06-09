using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.GenreController;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Data.Repositories;

namespace BookShopCourseWork.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository repository { get; set; }
        public GenreService()
        {
            repository = new GenreRepository();
        }
        public bool AddGenre(Genre genre)
        {
            return repository.AddGenre(genre);
        }
        public bool DeleteGenre(DeleteGenre genre)
        {
            return repository.DeleteGenre(genre);
        }
        public bool UpdateGenreBook(UpdateGenreBook updateGenreBook)
        {
            return repository.UpdateGenreBook(updateGenreBook);
        }
    }
}