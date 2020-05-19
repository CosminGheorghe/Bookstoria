using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstoria.AplicationLogic.Model;
using Bookstoria.AplicationLogic.Services;
using Bookstoria.Models.Admins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstoria.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly AdminService adminService;
        public AdminController(UserManager<IdentityUser> userManager, AdminService adminService)
        {
            this.userManager = userManager;
            this.adminService = adminService;
        }

        public ActionResult Index()
        {
            try
            {
                var userId = userManager.GetUserId(User);
                var admin = adminService.GetAdminByUserId(userId);
                var books = adminService.GetBooks();

                return View(new AdminBooksViewModel { Admin = admin, Books = books });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook([FromForm]AdminAddBookViewModel model)
        {
            string image = "";
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var memoryStream = new MemoryStream())
            {
                model.Image.CopyTo(memoryStream);

                image = Convert.ToBase64String(memoryStream.ToArray());
            }
            
            adminService.AddBook(model.Title, model.Author, model.CategoryType, model.DiscountValue, image, model.ISBN, model.Price);
            return Redirect(Url.Action("Index", "Admin"));

        }

        [HttpGet]
        public IActionResult DeleteBook([FromRoute]string id)
        {
            var book = adminService.GetBook(id);
            var bookVM = new AdminDeleteBookViewModel
            {
                Title = book.Title
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult DeleteBook([FromForm]AdminDeleteBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            adminService.DeleteBookByTitle(model.Title);
            return Redirect(Url.Action("Index", "Admin"));
        }

        [HttpGet]
        public IActionResult EditBook([FromRoute]string id)
        {

            var book = adminService.GetBook(id);
            var bookVM = new AdminEditBookViewModel 
            { 
                ID = book.ID, 
                Author = book.Author, 
                CategoryType = null, 
                DiscountValue = 0,

                ISBN = book.ISBN, 
                Price = book.Price, 
                Title = book.Title 
            };
            
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult EditBook([FromForm]AdminEditBookViewModel model)
        {
            string image = "";

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var memoryStream = new MemoryStream())
            {
                model.Image.CopyTo(memoryStream);

                image = Convert.ToBase64String(memoryStream.ToArray());
            }

            var book = new Book
            {
                ID = model.ID,
                Author = model.Author,
                Category = new Category() { ID = Guid.NewGuid(), Type = model.CategoryType },
                Discount = new Discount() { ID = Guid.NewGuid(), Value = model.DiscountValue },
                Image = image,
                ISBN = model.ISBN,
                Price = model.Price,
                Title = model.Title
            };
            adminService.EditBook(book);
            return Redirect(Url.Action("Index", "Admin"));
        }

    }
}