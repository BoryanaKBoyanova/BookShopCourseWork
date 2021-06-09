using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.PublisherController;
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
        public bool AddPublisher(Publisher publisher)
        {
            return repository.AddPublisher(publisher);
        }
        public bool DeletePublisher(DeletePublisher publisher)
        {
            return repository.DeletePublisher(publisher);
        }
        public bool UpdatePublisherBook(UpdatePublisherBook publisherBook)
        {
            return repository.UpdatePublisherBook(publisherBook);
        }
    }
}