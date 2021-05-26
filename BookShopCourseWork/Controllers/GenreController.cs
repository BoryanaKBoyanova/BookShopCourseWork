using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.GenreController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    [Route("~/Genre")]
    public class GenreController : Controller
    {
        private IGenreService genreService { get; set; }
        public GenreController()
        {
            genreService = new GenreService();
        }
        [Authorize(Policy = "adminOnly")] 
        [HttpPost("AddGenre")]
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
        [Authorize(Policy = "adminOnly")] 
        [HttpPost("DeleteGenre")]
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
        [Authorize(Policy = "adminOnly")] 
        [HttpPost("AddGenreBok")]
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