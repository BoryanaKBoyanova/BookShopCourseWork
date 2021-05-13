using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.GenreController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    public class GenreController : Controller
    {
        private IGenreService genreService { get; set; }
        public GenreController()
        {
            genreService = new GenreService();
        }

        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            if (User.Identity.IsAuthenticated)
            {
                if(ModelState.IsValid)
                {
                    return Ok(genreService.AddGenre(genre));
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
        public IActionResult DeleteGenre(DeleteGenre genre)
        {
            if (User.Identity.IsAuthenticated)
            {
                if(ModelState.IsValid)
                {
                    return Ok(genreService.DeleteGenre(genre));
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
        public IActionResult AddGenreBook(AddGenreBook addGenreBook)
        {
            if (User.Identity.IsAuthenticated)
            {
                if(ModelState.IsValid)
                {
                    return Ok(genreService.AddGenreBook(addGenreBook));
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