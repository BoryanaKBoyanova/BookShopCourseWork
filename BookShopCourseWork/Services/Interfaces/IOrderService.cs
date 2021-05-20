using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models.OrderController;
using BookShopCourseWork.Models;

namespace BookShopCourseWork.Services.Interfaces
{
    public interface IOrderService
    {
        public bool CreateOrder(CreateOrder order, string userEmail);
        public bool ChangeStatus(ChangeStatus changeStatus);
    }
}