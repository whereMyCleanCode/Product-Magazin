using System;
using EfLesson.Models;
namespace EfLesson.BL.AdminHub
{
	public interface IAdminHub
	{
		public void AddOrUpdateProduct(Product product);
		public void AddOrUpdateProduct(string name);
        public void AddOrUpdateProduct(int id);

        public void DeleteProduct(int id);///{
        public void DeleteProduct(string name);///}

    }
}

