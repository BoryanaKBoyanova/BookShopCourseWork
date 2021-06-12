using BookShopCourseWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BookShopCourseWork.Services;
using BookShopCourseWork.Services.Interfaces;
using System.Threading.Tasks;

namespace BookShopCourseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBookService bookService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            bookService = new BookService();
        }

        public IActionResult Index()
        {
            List<Book> books = bookService.GetAllBooks();
            books = books.OrderByDescending(b=> b.PublishedOn.Date).ToList();
            books = books.Take(8).ToList();
            return View(books);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
