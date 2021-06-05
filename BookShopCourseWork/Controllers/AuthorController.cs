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
            if(ModelState.IsValid)
            {
                return Ok(authorService.AddAuthor(author));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("DeleteAuthor")]
        public IActionResult DeleteAuthor(DeleteAuthor author)
        {
            if(ModelState.IsValid)
            {
                return Ok(authorService.DeleteAuthor(author));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
