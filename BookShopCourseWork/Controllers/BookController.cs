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

        private IGenreService genreService { get; set; }
        private IAuthorService authorService { get; set; }
        public BookController()
        {
            bookService = new BookService();
            genreService = new GenreService();
            authorService = new AuthorService();
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
        public IActionResult ViewAllBooks([FromQuery] int page, [FromQuery] string order, [FromQuery] string search, [FromQuery] string authors, [FromQuery] string genres)
        {
            if(page==0)
            {
                return NotFound();
            }
            if(order==null)
            {
                return BadRequest();
            }
            List<Genre> genresList = genreService.GetAllGenres();
            List<Author> authorsList = authorService.GetAllAuthors();
            List<Book> books = bookService.GetAllBooks();
            if(search!=null)
            {
                books = books.Where(b=> b.Title.ToLower().Contains(search.ToLower())).ToList();
            }
            if(authors!=null)
            {
                List<int> authorsId = authors.Split(',').Select(Int32.Parse).ToList();
                books = books.Where(b => b.Authors.Any(a=> authorsId.Contains(a.Id))).ToList();
            }
            if(genres!=null)
            {
                List<int> genresId = genres.Split(',').Select(Int32.Parse).ToList();
                books = books.Where(b => b.Genres.Any(g=> genresId.Contains(g.Id))).ToList();
            }
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
            if(books.Count == 0)
            {
                return View(new ViewBooksModel() { NumberOfBooks = 0, Authors = authorsList, Genres = genresList});
            }
            if(booksnum>books.Count)
            {
                try
                {
                    if(books.Count-(booksnum-16) == 0)
                    {
                        return NotFound();
                    }
                    return View(new ViewBooksModel() { Books = books.GetRange(booksnum-16, books.Count-(booksnum-16)), NumberOfBooks = books.Count, Authors = authorsList, Genres = genresList});
                }
                catch
                {
                    return NotFound();
                }
            }
            return View(new ViewBooksModel() {Books = books.GetRange(booksnum-16, 16), NumberOfBooks = books.Count, Authors = authorsList, Genres = genresList});
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
