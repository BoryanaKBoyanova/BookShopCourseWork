using Microsoft.AspNetCore.Mvc;
using System;
using BookShopCourseWork.Extensions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using BookShopCourseWork.Models;
using BookShopCourseWork.Models.AdminController;
using BookShopCourseWork.Services.Interfaces;
using BookShopCourseWork.Services;
using BookShopCourseWork.Models.Enums;
using BookShopCourseWork.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BookShopCourseWork.Controllers
{
    [Authorize(Policy = "adminOnly")] 
    [Route("~/Admin")]
    public class AdminController : Controller
    {
        private IBookService bookService { get; set; }
        private IOrderService orderService { get; set; }

        private IGenreService genreService {get; set;}

        private readonly UserManager<User> _userManager;
        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
            bookService = new BookService();
            orderService = new OrderService();
            genreService = new GenreService();

        }
        [HttpGet("CreateBook")]
        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpGet("EditBook")]
        public IActionResult EditBook()
        {
            return View();
        }
        [HttpGet("ViewOrdersByStatus/{status}")]
        public IActionResult ViewOrdersByStatus(string status)
        {
            if(Enum.IsDefined(typeof(OrderStatus), status))
            {
                return View(orderService.GetOrdersByStatus(status));
            }
            else if(status=="none")
            {
                return View(orderService.GetOrdersByStatus(status));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("ViewAndEditOrder/{id}")]
        public async Task<IActionResult> ViewAndEditOrder([FromRoute] int id)
        {
            if(id!=0)
            {
                Order order = orderService.GetOrderByIdAdmin(id);
                if(order!=null)
                {
                    User u = await _userManager.FindByEmailAsync(order.UserEmail);
                    OrderAndUserInfo oui = new OrderAndUserInfo(){Order = order, FirstName=u.FirstName, LastName=u.LastName};
                    return View(oui);
                }
                else
                {
                    return RedirectToAction("404", "Error");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("FindOrderById")]
        public IActionResult FindOrderById()
        {
            return View();
        }
        [HttpGet("UpdateAuthorBook")]
        public IActionResult UpdateAuthorBook()
        {
            return View();
        }
    }
}