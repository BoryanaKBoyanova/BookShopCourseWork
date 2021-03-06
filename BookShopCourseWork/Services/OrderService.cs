using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.OrderController;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Data.Repositories;
using BookShopCourseWork.Models.Enums;

namespace BookShopCourseWork.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository repository { get; set; }
        public OrderService()
        {
            repository = new OrderRepository();
        }
        public bool CreateOrder(CreateOrder order, string userEmail)
        {
            return repository.CreateOrder(order, userEmail);
        }
        public bool ChangeStatus(ChangeStatus changeStatus)
        {
            return repository.ChangeStatus(changeStatus);
        }
        public List<Order> GetOrdersByUser(string email)
        {
            return repository.GetOrdersByUser(email);
        }
        public Order GetOrderById(string email, int id)
        {
            return repository.GetOrderById(email, id);
        }
        public List<Order> GetOrdersByStatus(string status)
        {
            return repository.GetOrderByStatus(status);
        }
        public Order GetOrderByIdAdmin(int Id)
        {
            return repository.GetOrderByIdAdmin(Id);
        }
    }
}