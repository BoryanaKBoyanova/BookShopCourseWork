using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.GenreController;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Data.Repositories;

namespace BookShopCourseWork.Services
{
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository repository { get; set; }
        public PublisherService()
        {
            repository = new PublisherRepository();
        }
    }
}