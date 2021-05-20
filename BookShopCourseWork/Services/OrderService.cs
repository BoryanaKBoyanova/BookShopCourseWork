using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.OrderController;
using BookShopCourseWork.Data.Interfaces;
using BookShopCourseWork.Data.Repositories;

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
    }
}