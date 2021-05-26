using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using BookShopCourseWork.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    public class PublisherController : Controller
    {
        private IPublisherService publisherService { get; set; }
        public PublisherController()
        {
            publisherService = new PublisherService();
        }
        


    }
}
