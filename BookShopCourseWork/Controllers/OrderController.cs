using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.OrderController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using BookShopCourseWork.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json;
namespace BookShopCourseWork.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService orderService { get; set; }
        public OrderController()
        {
            orderService = new OrderService();
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrder order)
        {
            if(User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        order.BooksAndQuantityParsed = JsonConvert.DeserializeObject<Dictionary<int, int>>(order.BooksAndQuantity);
                        return Ok(orderService.CreateOrder(order, User.Identity.Name));
                    }
                    catch
                    {
                        return BadRequest();
                    }
                    
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        public IActionResult ChangeStatus(ChangeStatus changeStatus)
        {
            if(User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    return Ok(orderService.ChangeStatus(changeStatus));
                    
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
