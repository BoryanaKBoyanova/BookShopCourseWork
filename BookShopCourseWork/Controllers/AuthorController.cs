using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using BookShopCourseWork.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    public class AuthorController : Controller
    {
        private IBookService bookService { get; set; }
        public AuthorController()
        {
            bookService = new BookService();
        }

    }
}
