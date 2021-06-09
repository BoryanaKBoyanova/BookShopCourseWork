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
        public bool AddPublisher(Publisher publisher)
        {
            if(context.Publishers.Any(p => p.PublisherName == publisher.PublisherName))
            {
                return false;
            }
            else
            {
                context.Publishers.Add(publisher);
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
            // Publisher p = context.Publishers.Find(publisherBook.PublisherId);
            // Book b = context.Books.Include(b => b.Publisher).Single(b => b.Id == publisherBook.BookId);
            // if(p == null && b == null)
            // {
            //     return false;
            // }
            // else
            // {
            //     b.Publisher = new List<Publisher>();
            //     b.Publisher.Add(p);
            //     context.SaveChanges();
            //     return true;
            // }
            return true;
        }

        
    }
}