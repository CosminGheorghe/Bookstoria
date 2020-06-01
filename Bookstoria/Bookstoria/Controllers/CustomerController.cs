using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstoria.AplicationLogic.Model;
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

        [HttpGet]
        public IActionResult AddToCart(string cart)
        {
            List<Book> bookList = new List<Book>();
            if (cart.Length > 1)
            {
                string[] splitId = cart.Split(';');
                for (int i = 0; i < splitId.Length; i++)
                {
                    if (splitId[i].Length > 0)
                    {
                        var book = bookService.GetBook(splitId[i]);
                        if (book != null)
                        {
                            bookList.Add(book);
                        }
                    }
                }
            }
            var viewModel = new CartVM()
            {
                books = bookList
            };
            return PartialView("_AddToCart", viewModel);
        }
        
        [HttpPost]
        public IActionResult AddToCart()
        {
            return Redirect(Url.Action("Index", "Customer"));
        }

    }
}