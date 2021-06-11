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
        public IActionResult AddGenre(AddGenre genre)
        {
            if(ModelState.IsValid)
            {
                bool status = genreService.AddGenre(genre);
                if (status)
                {
                    return RedirectToAction("Success", "Admin", new { message = "AddGenre" });
                }
                else
                {
                    return RedirectToAction("Failed", "Admin", new { message = "AddGenre" });
                }
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
                bool status = genreService.DeleteGenre(genre);
                if (status)
                {
                    return RedirectToAction("Success", "Admin", new { message = "DeleteGenre" });
                }
                else
                {
                    return RedirectToAction("Failed", "Admin", new { message = "DeleteGenre" });
                }
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
                bool status = genreService.UpdateGenreBook(genreBook);
                if (genreBook.Operation == "addGenre")
                {
                    if (status)
                    {
                        return RedirectToAction("Success", "Admin", new { message = "BookGenreConnected" });
                    }
                    else
                    {
                        return RedirectToAction("Failed", "Admin", new { message = "BookGenreConnected" });
                    }
                }
                else if (genreBook.Operation == "removeGenre")
                {
                    if (status)
                    {
                        return RedirectToAction("Success", "Admin", new { message = "BookGenreDisconnected" });
                    }
                    else
                    {
                        return RedirectToAction("Failed", "Admin", new { message = "BookGenreDisconnected" });
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