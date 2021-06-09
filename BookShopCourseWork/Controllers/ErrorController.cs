using Microsoft.AspNetCore.Mvc;
using System;
using BookShopCourseWork.Extensions;
using System.Collections.Generic;
using System.Linq;
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
    [Route("~/Error")]
    public class ErrorController : Controller
    {
        [HttpGet("404")]
        public IActionResult NotFoundPage()
        {
            return View();
        }
     
    }
}
