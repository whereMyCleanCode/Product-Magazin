using System;
using EfLesson.ViewModels;
using EfLesson.Models;
namespace EfLesson.BL.GiveMeMyBasket
{
	public interface IIdentityBasket
	{
		public void CreateBasket(List<Product> menu, int userid);
		public void UpdateBasket(List<MenuViewModel> menu);
		public void UpdateBasket(List<Product> product);
    }
}

