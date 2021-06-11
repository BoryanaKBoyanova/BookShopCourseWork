using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.PublisherController;

namespace BookShopCourseWork.Data.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private ApplicationDbContext context;
        public PublisherRepository()
        {
            context = new ApplicationDbContext();
        }
        public List<Publisher> GetAllPublishers()
        {
            return context.Publishers.ToList();
        }
        public bool AddPublisher(AddPublisher publisher)
        {
            if(context.Publishers.Any(p => p.PublisherName == publisher.PublisherName))
            {
                return false;
            }
            else
            {
                context.Publishers.Add(new Publisher(){PublisherName = publisher.PublisherName});
                context.SaveChanges();
                return true;
            }

        }
        public bool DeletePublisher(DeletePublisher publisher)
        {
            Publisher p = context.Publishers.Find(publisher.PublisherId);
            if(p!=null)
            {
                context.Publishers.Remove(p);
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdatePublisherBook(UpdatePublisherBook publisherBook)
        {
            Publisher p = context.Publishers.Find(publisherBook.PublisherId);
            Book b = context.Books.Find(publisherBook.BookId);
            if(p != null && b!= null)
            {
                b.Publisher = p;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}