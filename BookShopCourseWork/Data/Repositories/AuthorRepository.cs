using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private ApplicationDbContext context;
        public AuthorRepository()
        {
            context = new ApplicationDbContext();
        }

    }
}