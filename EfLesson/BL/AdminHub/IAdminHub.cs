using System;
using EfLesson.BL.IBlInterface;
using EfLesson.Models;
using EfLesson.ViewModels;
namespace EfLesson.BL.AdminHub
{
	public interface IAdminHub : IBaseProduct
	{
		public void AddOrUpdateProduct(AdminProductViewModel product);
        public void DeleteProduct(AdminProductViewModel product);

    }
}

