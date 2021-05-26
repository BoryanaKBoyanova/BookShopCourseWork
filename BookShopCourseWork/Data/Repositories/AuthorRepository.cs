using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Models.AuthorController;
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

        public bool AddAuthor(AddAuthor author)
        {
            if(!context.Authors.Any(a => a.FirstName == author.FirstName && a.LastName == author.LastName))
            {
                context.Authors.Add(new Author(){FirstName = author.FirstName, LastName = author.LastName});
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteAuthor(DeleteAuthor author)
        {
            Author a = context.Authors.Find(author.AuthorId);
            if(a!=null)
            {
                context.Authors.Remove(a);
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