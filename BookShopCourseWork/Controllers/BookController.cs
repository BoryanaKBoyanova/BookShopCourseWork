using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    public class BookController : Controller
    {
        private IBookService bookService { get; set; }
        public BookController()
        {
            bookService = new BookService();
        }
        [HttpPost]
        public bool CreateBook(Book book, Publisher publisher)
        {
            if (User.Identity.IsAuthenticated)
            {
                return bookService.CreateBook(book, publisher);
            }
            else
            {
                 return new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
