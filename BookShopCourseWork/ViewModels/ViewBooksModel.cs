namespace BookShopCourseWork.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using BookShopCourseWork.Models;

    public class ViewBooksModel
    {
        public List<Book> Books {get; set;}

        public List<Author> Authors {get; set;}
    }
}
