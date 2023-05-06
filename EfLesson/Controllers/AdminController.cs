using System;
using EfLesson.Models;
using EfLesson.BL.AdminHub;
using Microsoft.AspNetCore.Mvc;

namespace EfLesson.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminHub _adminHub;

        public AdminController(Product product, IAdminHub adminHub)
        {
            _adminHub = adminHub;
        }

        [HttpGet]
        [Route("Admin_Hub")]
        public async Task<IActionResult> Index()
        {
            return View("Index", new Product());
        }

      ///  [HttpPost]
       /// [Route("Admin_Hub")]
     ///   public async Task<IActionResult> IndexPost()
     ///   {
     ///       
     ///   }
    }
}

