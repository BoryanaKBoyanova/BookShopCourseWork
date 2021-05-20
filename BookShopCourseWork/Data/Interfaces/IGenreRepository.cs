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
        public bool AddGenre(Genre genre);

        public bool DeleteGenre(DeleteGenre genre);

        public bool AddGenreBook(AddGenreBook addGenreBook);

    }
}