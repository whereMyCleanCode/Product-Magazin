using System;
using EfLesson.BL.IBlInterface;
using EfLesson.Models;

namespace EfLesson.BL
{
	public interface IIdentityProduct : IBaseProduct
	{
		public IEnumerable<ProductModel> GetProduct();

        public IEnumerable<ProductModel> GetProduct(string param);

        public IEnumerable<ProductModel> GetProduct(int param);

    }


}

