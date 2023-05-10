using System;
namespace EfLesson.ViewModels
{
	public class BasketViewModel
	{
		public List<MenuViewModel> AllProduct { get; set; }

		public double AllPrice { get; set; }

		public bool StatusPayment { get; set; } = false;

		public string StatusDelivery { get; set; } = "Ожидает оплату";
	}
}

