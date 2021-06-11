using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models.GenreController;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Data.Interfaces
{
    interface IGenreRepository
    {
        public bool AddGenre(AddGenre genre);
        public bool DeleteGenre(DeleteGenre genre);
        public bool UpdateGenreBook(UpdateGenreBook genreBook);
        public List<Genre> GetAllGenres();

    }
}