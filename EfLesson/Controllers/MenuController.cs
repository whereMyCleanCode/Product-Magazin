using System;
using Microsoft.AspNetCore.Mvc;
using EfLesson.BL;
using EfLesson.ViewModel;
using EfLesson.Models;

namespace EfLesson.Controllers
{
	public class MenuController : Controller
	{
		private IIdentityProduct _identityProduct;

		public MenuController(IIdentityProduct identityProduct)
		{
			_identityProduct = identityProduct;
        }

        [HttpGet]
		[Route("/Menu")]
		public IActionResult Index()
		{
			MenuViewModel menu = new MenuViewModel();
			menu.products = _identityProduct.GetProduct();

            return View("Index", menu);

        }
	}
}

