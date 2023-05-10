using System;
using EfLesson.Models;
using EfLesson.BL.AdminHub;
using EfLesson.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EfLesson.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminHub _adminHub;

        public AdminController(IAdminHub adminHub)
        {
            _adminHub = adminHub;
        }

        [HttpGet]
        [Route("Admin")]
        public IActionResult Index()
        {
            return View("Index", new AdminProductViewModel());
        }

        [HttpPost]
        [Route("Admin")]
        public async Task<IActionResult> IndexPost(AdminProductViewModel model)
        {
            if(model.DeleteProduct)
            {
                _adminHub.AddOrUpdateProduct(model);
            }
            return View();
        }
    }
}

