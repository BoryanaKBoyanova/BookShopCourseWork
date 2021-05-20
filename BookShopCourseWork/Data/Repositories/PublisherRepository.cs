using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Data.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private ApplicationDbContext context;
        public PublisherRepository()
        {
            context = new ApplicationDbContext();
        }
        
    }
}