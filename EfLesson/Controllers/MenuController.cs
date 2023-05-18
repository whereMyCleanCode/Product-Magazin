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
			IEnumerable<ProductModel> product = _identityProduct.GetProduct();
			List<MenuViewModel> menu = new List<MenuViewModel>();

			foreach(ProductModel p in product)
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
			List<ProductModel> products = new List<ProductModel>();
			///int? userid = _identityUser.GetUser();
			if (menu != null)
				foreach(MenuViewModel productmenu in menu)
				{
					products.Add(new ProductModel
					{
						ProductName = productmenu.ProductName,
						ProductPrice = productmenu.ProductPrice,

					});
                }
			return View();
			///_identityBasket.CreateBasket();
		}
	}
}

