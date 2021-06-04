using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using BookShopCourseWork.Models.OrderController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using Newtonsoft.Json;
namespace BookShopCourseWork.Controllers
{
    [Route("~/Order")]
    public class OrderController : Controller
    {
        private IOrderService orderService { get; set; }
        public OrderController()
        {
            orderService = new OrderService();
        }
        [HttpGet("Cart")]
        [Authorize(Policy = "loginRequired")] 
        public IActionResult Cart()
        {
            return View();
        }
        [HttpGet("FinishOrder")]
        [Authorize(Policy = "loginRequired")] 
        public IActionResult FinishOrder()
        {
            return View();
        }
        [HttpGet("OrderSuccess")]
        [Authorize(Policy = "loginRequired")] 
        public IActionResult OrderSuccess()
        {
            return View();
        }
        [Authorize(Policy = "loginRequired")] 
        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(CreateOrder order)
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
        [Authorize(Policy = "loginRequired")] 
        [HttpGet("ViewOrders")]
        public IActionResult ViewOrders()
        {
            return View(orderService.GetOrdersByUser(User.Identity.Name));
        }
        [Authorize(Policy = "adminOnly")] 
        [HttpPost("ChangeStatus")]
        public IActionResult ChangeStatus(ChangeStatus changeStatus)
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
    }
}
