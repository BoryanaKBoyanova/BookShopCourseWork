using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models.PublisherController;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Services.Interfaces
{
    public interface IPublisherService
    {
        public bool AddPublisher(Publisher publisher);
        public bool DeletePublisher(DeletePublisher publisher);
        public bool UpdatePublisherBook(UpdatePublisherBook publisherBook);
    }
}