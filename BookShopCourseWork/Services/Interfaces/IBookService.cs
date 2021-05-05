using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Services.Interfaces
{
    public interface IBookService
    {
        public bool CreateBook(Book book, Publisher publisher);
    }
}
