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

namespace Bookstoria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AdminService _adminService;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, AdminService adminService)
        {
            _logger = logger;
            _userManager = userManager;
            _adminService = adminService;
        }

        public IActionResult Index()
        {
           
            var userId = _userManager.GetUserId(User);
            
            if(userId != null)
            {
                var admin = _adminService.GetAdminByUserId(userId);
                if (admin != null)
                {
                    var books = _adminService.GetBooks();

                    return View(new AdminBooksViewModel { Admin = admin, Books = books });

                }
            }
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
