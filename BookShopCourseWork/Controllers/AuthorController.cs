using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.AuthorController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using BookShopCourseWork.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    [Authorize(Policy = "adminOnly")]
    [Route("~/Author")]
    public class AuthorController : Controller
    {
        private IAuthorService authorService { get; set; }
        public AuthorController()
        {
            authorService = new AuthorService();
        }
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor(AddAuthor author)
        {
            if (ModelState.IsValid)
            {
                bool status = authorService.AddAuthor(author);
                if (status)
                {
                    return RedirectToAction("Success", "Admin", new { message = "AddAuthor" });
                }
                else
                {
                    return RedirectToAction("Failed", "Admin", new { message = "AddAuthor" });
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("DeleteAuthor")]
        public IActionResult DeleteAuthor(DeleteAuthor author)
        {
            if (ModelState.IsValid)
            {
                bool status = authorService.DeleteAuthor(author);
                if (status)
                {
                    return RedirectToAction("Success", "Admin", new { message = "DeleteAuthor" });
                }
                else
                {
                    return RedirectToAction("Failed", "Admin", new { message = "DeleteAuthor" });
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("UpdateAuthorBook")]
        public IActionResult UpdateAuthorBook(UpdateAuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                bool status = authorService.UpdateAuthorBook(authorBook);
                if (authorBook.Operation == "addAuthor")
                {
                    if (status)
                    {
                        return RedirectToAction("Success", "Admin", new { message = "BookAuthorConnected" });
                    }
                    else
                    {
                        return RedirectToAction("Failed", "Admin", new { message = "BookAuthorConnected" });
                    }
                }
                else if (authorBook.Operation == "removeAuthor")
                {
                    if (status)
                    {
                        return RedirectToAction("Success", "Admin", new { message = "BookAuthorDisconnected" });
                    }
                    else
                    {
                        return RedirectToAction("Failed", "Admin", new { message = "BookAuthorDisconnected" });
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
