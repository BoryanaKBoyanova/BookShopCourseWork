using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.PublisherController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using BookShopCourseWork.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    [Authorize(Policy = "adminOnly")]
    public class PublisherController : Controller
    {
        private IPublisherService publisherService { get; set; }
        public PublisherController()
        {
            publisherService = new PublisherService();
        }
        [HttpPost("AddPublisher")]
        public IActionResult AddPublisher(Publisher publisher)
        {
            if(ModelState.IsValid)
            {
                return Ok(publisherService.AddPublisher(publisher));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("DeletePublisher")]
        public IActionResult DeletePublisher(DeletePublisher publisher)
        {
            if(ModelState.IsValid)
            {
                return Ok(publisherService.DeletePublisher(publisher));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("UpdatePublisherBook")]
        public IActionResult UpdatePublisherBook(UpdatePublisherBook publisherBook)
        {
            if(ModelState.IsValid)
            {
                return Ok(publisherService.UpdatePublisherBook(publisherBook));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
