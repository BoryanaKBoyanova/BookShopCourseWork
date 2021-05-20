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
    public class BookController : Controller
    {
        private IBookService bookService { get; set; }
        public BookController()
        {
            bookService = new BookService();
        }

        public IActionResult ViewAllBooks()
        {
            return View( bookService.GetAllBooks());
        }
        [HttpPost]
        public IActionResult EditBook(EditBook book)
        {
            if (User.Identity.IsAuthenticated)
            {
                if(ModelState.IsValid)
                {
                    return Ok(bookService.EditBook(book));
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public IActionResult CreateBook(Book book, Publisher publisher, Author author)
        {
            //sif (User.Identity.IsAuthenticated)
            ///{
                if(ModelState.IsValid)
                {
                    return Ok(bookService.CreateBook(book, publisher, author));
                }
                else
                {
                    return BadRequest();
                }
            //}
            //else
            //{
               //return Unauthorized();
            //}
        }
        [HttpPost]
        public IActionResult DeleteBook(DeleteBook book)
        {
            if (User.Identity.IsAuthenticated)
            {
                if(ModelState.IsValid)
                {
                    return Ok(bookService.DeleteBook(book));
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
