using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstoria.AplicationLogic.Services;
using Bookstoria.Models.Admins;
using Microsoft.AspNetCore.Authorization;
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
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), model.Image);

            byte[] image = Encoding.ASCII.GetBytes(path);
            adminService.AddBook(model.Title, model.Author, model.CategoryType, model.DiscountValue, image, model.ISBN, model.Price);
            return Redirect(Url.Action("Index", "Admin"));

        }

        [HttpPost]
        public IActionResult DeleteBook([FromForm]AdminDeleteBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            adminService.DeleteBook(model.Title);
            return View();
        }

    }
}