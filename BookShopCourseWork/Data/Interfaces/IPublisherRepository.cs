using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models.BookController;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.PublisherController;

namespace BookShopCourseWork.Data.Interfaces
{
    interface IPublisherRepository
    {
        public bool AddPublisher(Publisher publisher);

        public bool DeletePublisher(DeletePublisher publisher);
        public bool UpdatePublisherBook(UpdatePublisherBook publisherBook);

    }
}