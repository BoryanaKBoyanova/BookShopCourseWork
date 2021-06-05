using Microsoft.AspNetCore.Mvc;
using System;
using BookShopCourseWork.Extensions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using BookShopCourseWork.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    [Authorize(Policy = "adminOnly")] 
    [Route("~/Admin")]
    public class AdminController : Controller
    {
        private IBookService bookService { get; set; }
        private IOrderService orderService { get; set; }

        private IGenreService genreService {get; set;}
        public AdminController()
        {
            bookService = new BookService();
            orderService = new OrderService();
            genreService = new GenreService();

        }
        [HttpGet("CreateBook")]
        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpGet("EditBook")]
        public IActionResult EditBook()
        {
            return View();
        }
    }
}