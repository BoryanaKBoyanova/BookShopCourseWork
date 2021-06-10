using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models.AuthorController;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Services.Interfaces
{
    public interface IAuthorService
    {
        public bool AddAuthor(AddAuthor author);
        public bool DeleteAuthor(DeleteAuthor author);

        public bool UpdateAuthorBook(UpdateAuthorBook authorBook);
        public List<Author> GetAllAuthors();
    }
}