using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Data.Repositories;

namespace BookShopCourseWork.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository repository { get; set; }
        public AuthorService()
        {
            repository = new AuthorRepository();
        }
    }
}