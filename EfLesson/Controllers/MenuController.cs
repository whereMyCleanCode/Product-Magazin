using System;
using Microsoft.AspNetCore.Mvc;
using EfLesson.BL;
using EfLesson.ViewModels;
using EfLesson.Models;
using EfLesson.BL.GiveMeMyBasket;

namespace EfLesson.Controllers
{
	public class MenuController : Controller
	{
		private IIdentityProduct _identityProduct;
		private IIdentityBasket _identityBasket;
		private IIdentityUser _identityUser;

		public MenuController(IIdentityProduct identityProduct)
		{
			_identityProduct = identityProduct;
        }

		[HttpGet]
		[Route("/Menu")]
		public IActionResult Index()
		{
			IEnumerable<Product> product = _identityProduct.GetProduct();
			List<MenuViewModel> menu = new List<MenuViewModel>();

			foreach(Product p in product)
			{
				menu.Add(new MenuViewModel
				{
					ProductPrice = p.ProductPrice,
					ProductCategory = p.ProductCategory,
					ProductName = p.ProductName,
					ProductPhoto = p.ProductPhoto
				});
            }
            return View("Index", menu);
        }

		[HttpPost]
		[Route("/Menu")]
		public IActionResult IndexPost(List<MenuViewModel> menu)
		{
			List<Product> products = new List<Product>();
			///int? userid = _identityUser.GetUser();
			if (menu != null)
				foreach(MenuViewModel productmenu in menu)
				{
                   {
					new Product
					{
						ProductName = productmenu.ProductName
					}
						});
                }
				
				_identityBasket.CreateBasket()
		}
	}
}

