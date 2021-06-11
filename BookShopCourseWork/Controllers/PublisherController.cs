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
        public IActionResult AddPublisher(AddPublisher publisher)
        {
            if(ModelState.IsValid)
            {
                bool status = publisherService.AddPublisher(publisher);
                if (status)
                {
                    return RedirectToAction("Success", "Admin", new { message = "AddPublisher" });
                }
                else
                {
                    return RedirectToAction("Failed", "Admin", new { message = "AddPublisher" });
                }
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
                bool status = publisherService.DeletePublisher(publisher);
                if (status)
                {
                    return RedirectToAction("Success", "Admin", new { message = "DeletePublisher" });
                }
                else
                {
                    return RedirectToAction("Failed", "Admin", new { message = "DeletePublisher" });
                }
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
                bool status = publisherService.UpdatePublisherBook(publisherBook);
                if (status)
                {
                    return RedirectToAction("Success", "Admin", new { message = "BookPublisherConnected" });
                }
                else
                {
                    return RedirectToAction("Failed", "Admin", new { message = "BookPublisherConnected" });
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
