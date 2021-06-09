using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.Enums;
using BookShopCourseWork.Models.OrderController;
namespace BookShopCourseWork.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;
        public OrderRepository()
        {
            context = new ApplicationDbContext();
        }

        public bool CreateOrder(CreateOrder order, string userEmail)
        {
            Order o = new Order();
            o.Address = order.Address;
            o.City = order.City;
            o.Date = DateTime.Now;
            o.Notes = order.Notes;
            o.UserEmail = userEmail;
            o.PhoneNumber = order.PhoneNumber;
            o.Total = 0;
            o.Status = OrderStatus.SENT.ToString();
            o.BookQuantities = new List<BookQuantity>();
            foreach (KeyValuePair<int, int> BookAndQuantity in order.BooksAndQuantityParsed)
            {
                Book b = context.Books.Find(BookAndQuantity.Key);
                if (b != null)
                {
                    o.Total += b.Price * BookAndQuantity.Value;
                    o.BookQuantities.Add(new BookQuantity() { Book = b, Quantity = BookAndQuantity.Value });
                }
            }
            o.Total = Math.Round(o.Total, 2, MidpointRounding.ToEven);
            context.Orders.Add(o);
            context.SaveChanges();
            return true;
        }

        public bool ChangeStatus(ChangeStatus changeStatus)
        {
            Order order = context.Orders.Find(changeStatus.OrderId);
            if (order != null)
            {
                switch (changeStatus.Status)
                {
                    case "SENT":
                        order.Status = OrderStatus.SENT.ToString();
                        break;
                    case "PROCESSING":
                        order.Status = OrderStatus.PROCESSING.ToString();
                        break;
                    case "DELIVERED":
                        order.Status = OrderStatus.DELIVERED.ToString();
                        break;
                    case "CANCELLED":
                        order.Status = OrderStatus.CANCELLED.ToString();
                        break;
                    default:
                        return false;
                }
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Order> GetOrders()
        {
            return context.Orders.Select(order => new Order()
            {
                City = order.City,
                Address = order.Address,
                Notes = order.Notes,
                UserEmail = order.UserEmail,
                Status = order.Status,
                Date = order.Date,
                PhoneNumber = order.PhoneNumber,
                Total = order.Total,
                BookQuantities = order.BookQuantities.Select(baq => baq).ToList()
            }).ToList();
        }
        public List<Order> GetOrderByStatus(string status)
        {
            if(status!="none")
            {
                return context.Orders.Where(o => o.Status == status).Select(order => new Order()
                {
                    Id = order.Id,
                    Date = order.Date,
                    Total = order.Total,
                }).ToList();
            }
            else
            {
                return context.Orders.Select(order => new Order()
                {
                    Id = order.Id,
                    Date = order.Date,
                    Total = order.Total,
                }).ToList();
            }
        }
        public List<Order> GetOrdersByUser(string email)
        {
            return context.Orders.Where(o => o.UserEmail == email).Select(order => new Order()
            {
                Id = order.Id,
                Date = order.Date,
                Total = order.Total,

            }).ToList();
        }
        public Order GetOrderByIdAdmin(int Id)
        {
            try
            {
                return context.Orders.Where(o => o.Id == Id).Select(order => new Order()
                {
                    Id = order.Id,
                    City = order.City,
                    Address = order.Address,
                    Notes = order.Notes,
                    UserEmail = order.UserEmail,
                    Date = order.Date,
                    Status = order.Status,
                    PhoneNumber = order.PhoneNumber,
                    Total = order.Total,
                    BookQuantities = order.BookQuantities.Select(baq => new BookQuantity()
                    {
                        Book = baq.Book,
                        Quantity = baq.Quantity
                    }).ToList()
                }).First();
            }
            catch
            {
                return null;
            }
        }
        public Order GetOrderById(string email, int Id)
        {
            try
            {
                return context.Orders.Where(o => o.UserEmail == email && o.Id == Id).Select(order => new Order()
                {
                    City = order.City,
                    Address = order.Address,
                    Notes = order.Notes,
                    UserEmail = order.UserEmail,
                    Date = order.Date,
                    Status = order.Status,
                    PhoneNumber = order.PhoneNumber,
                    Total = order.Total,
                    BookQuantities = order.BookQuantities.Select(baq => new BookQuantity()
                    {
                        Book = baq.Book,
                        Quantity = baq.Quantity
                    }).ToList()
                }).First();
            }
            catch
            {
                return null;
            }
        }

    }
}