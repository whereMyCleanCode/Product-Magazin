using System;
using EfLesson.BL.IBlInterface;
using EfLesson.Models;

namespace EfLesson.BL
{
	public interface IIdentityProduct : IBaseProduct
	{
		public IEnumerable<Product> GetProduct();

        public IEnumerable<Product> GetProduct(string param);

        public IEnumerable<Product> GetProduct(int param);

    }


}

