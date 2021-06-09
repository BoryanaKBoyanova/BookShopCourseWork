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
    [Authorize(Policy = "adminOnly")] 
    [Route("~/Genre")]
    public class GenreController : Controller
    {
        private IGenreService genreService { get; set; }
        public GenreController()
        {
            genreService = new GenreService();
        }
        [HttpPost("AddGenre")]
        public IActionResult AddGenre(Genre genre)
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
        [HttpPost("DeleteGenre")]
        public IActionResult DeleteGenre(DeleteGenre genre)
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
        [HttpPost("UpdateGenreBook")]
        public IActionResult UpdateGenreBook(UpdateGenreBook genreBook)
        {
            if(ModelState.IsValid)
            {
                return Ok(genreService.UpdateGenreBook(genreBook));
            }
            else
            {
                return BadRequest();
            }
        }

    }
}