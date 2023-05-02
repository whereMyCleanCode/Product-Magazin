using System;
using EfLesson.Models;

namespace EfLesson.BL
{
	public interface IIdentityProduct
	{
		public IEnumerable<Product> GetProduct();

        public IEnumerable<Product> GetProduct(string param);

        public IEnumerable<Product> GetProduct(int param);

    }


}

