using Microsoft.AspNetCore.Mvc;
using System;
using BookShopCourseWork.Extensions;
using System.Collections.Generic;
using System.Linq;
using BookShopCourseWork.Models.AdminController;
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
    [Route("~/Book")]
    public class BookController : Controller
    {
        private IBookService bookService { get; set; }
        public BookController()
        {
            bookService = new BookService();
        }
        [HttpGet("{id}")]
        public IActionResult Index([FromRoute] int id)
        {
            if (id != 0)
            {
                Book book = bookService.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(book);
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetBookByIdJson/{id}")]
        public IActionResult GetBookByIdJson([FromRoute] int id)
        {
            if (id != 0)
            {
                Book book = bookService.GetBookById(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Json(book);
                }
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("ViewAllBooks")]
        public IActionResult ViewAllBooks([FromQuery] int page, [FromQuery] string order)
        {
            if(page==0)
            {
                return NotFound();
            }
            if(order==null)
            {
                return BadRequest();
            }
            List<Book> books = bookService.GetAllBooks();
            switch(order)
            {
                case "priceAscending":
                    books = books.OrderBy(b=>b.Price).ToList();
                break;
                case "priceDescending":
                    books = books.OrderByDescending(b=>b.Price).ToList();
                break;
                case "titleAscending":
                    books = books.OrderBy(b=>b.Title,  new AlphanumComparatorFast()).ToList();
                break;
                case "titleDescending":
                    books = books.OrderByDescending(b=>b.Title, new AlphanumComparatorFast()).ToList();
                break;
                case "publishAscending":
                    books = books.OrderBy(b=>b.Id).ToList();
                break;
                case "publishDescending":
                    books = books.OrderByDescending(b=>b.Id).ToList();
                break;
                case "releaseAscending":
                    books = books.OrderBy(b=>b.PublishedOn).ToList();
                break;
                case "releaseDescending":
                    books = books.OrderByDescending(b=>b.PublishedOn).ToList();
                break;
                default:
                return BadRequest();
            }
            int booksnum = page * 16;
            if(booksnum>books.Count)
            {
                try
                {
                    if(books.Count-(booksnum-16) == 0)
                    {
                        return NotFound();
                    }
                    return View(new ViewBooksModel() { Books = books.GetRange(booksnum-16, books.Count-(booksnum-16)), NumberOfBooks = books.Count});
                }
                catch
                {
                    return NotFound();
                }
            }
            return View(new ViewBooksModel() {Books = books.GetRange(booksnum-16, 16), NumberOfBooks = books.Count});
        }
        [Authorize(Policy = "adminOnly")] 
        [HttpPost("EditBook")]
        public IActionResult EditBook(EditBook book)
        {
                if (ModelState.IsValid)
                {
                    bool status = bookService.EditBook(book);
                    if(status)
                    {
                        return RedirectToAction("Success", "Admin", new { message = "EditBook" });
                    }
                    else
                    {
                        return RedirectToAction("Failed", "Admin", new { message = "EditBook" });
                    }
                }
                else
                {
                    return BadRequest();
                }
        } 
        [Authorize(Policy = "adminOnly")] 
        [HttpPost("CreateBook")]
        public IActionResult CreateBook(CreateBook book)
        {
                if (ModelState.IsValid)
                {
                    bool status = bookService.CreateBook(book);
                    if(status)
                    {
                        return RedirectToAction("Success", "Admin", new { message = "CreateBook" });
                    }
                    else
                    {
                        return RedirectToAction("Failed", "Admin", new { message = "CreateBook" });
                    }
                }
                else
                {
                    return BadRequest();
                }
        }
    }
}
