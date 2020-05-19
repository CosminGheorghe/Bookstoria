using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstoria.AplicationLogic.Services;
using Bookstoria.Models.Customers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstoria.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly CustomersServices customersServices;
        private readonly BookService bookService;

        public CustomerController(UserManager<IdentityUser> userManager, BookService bookService, CustomersServices customersServices)
        {
            this.userManager = userManager;
            this.bookService = bookService;
            this.customersServices = customersServices;
        }

        public IActionResult Index()
        {
            var books = bookService.GetBooks();
            return View(new CustomerViewModel { Books = books });
        }
    }
}