using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookstoria.Models;
using Microsoft.AspNetCore.Identity;
using Bookstoria.AplicationLogic.Model;
using Bookstoria.AplicationLogic.Services;
using Bookstoria.Models.Admins;
using Bookstoria.Models.Home;
using Bookstoria.AplicationLogic.Exceptions;

namespace Bookstoria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AdminService _adminService;
        private readonly CustomersServices _customersServices;
        private readonly BookService _bookService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, AdminService adminService, CustomersServices customersServices, BookService bookService)
        {
            _logger = logger;
            _userManager = userManager;
            _adminService = adminService;
            _customersServices = customersServices;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
           
            var userId = _userManager.GetUserId(User);
            
            if(userId != null)
            {
                try
                {
                    var admin = _adminService.GetAdminByUserId(userId);
                    return RedirectToAction("Index", "Admin");
                }
                catch(EntityNotFoundException)
                {
                    return RedirectToAction("Index", "Customer");
                }
                    
            }

            var homeVM = new HomeViewModel { Books = _bookService.GetBooks() };

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SingleBook([FromRoute]string id)
        {
            var book = _bookService.GetBook(id);
            var bookVM = new SingleBookVM
            {
                ID = book.ID,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price,
                ISBN = book.ISBN,
                ImageData = book.Image,
                CategoryType = book.Category.Type,
                DiscountValue = book.Discount.Value,
            };
            return View(bookVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
