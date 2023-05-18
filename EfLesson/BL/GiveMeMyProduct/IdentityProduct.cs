using System;
using System.Linq;
using EfLesson.DAL;
using EfLesson.Models;

namespace EfLesson.BL
{
    public class IdentityProduct : IIdentityProduct
    {
        private ProductDb _identityMenuDb;

        public IdentityProduct(ProductDb identityMenuDb)
        {
            _identityMenuDb = identityMenuDb;
        }

        public IEnumerable<ProductModel> GetProduct()
        {
            IEnumerable<ProductModel> products = _identityMenuDb.Products.ToList();

            return products;
        }

        public IEnumerable<ProductModel> GetProduct(string param)
        {
            IEnumerable<ProductModel> products =  _identityMenuDb.Products
                                            .Where(e => e.ProductCategory == param
                                            || e.ProductName == param)
                                            .ToList();
            return products;
        }

        public IEnumerable<ProductModel> GetProduct(int param)
        {
            IEnumerable<ProductModel> products = _identityMenuDb.Products
                                          .Where(e => e.ProductPrice == param)
                                          .ToList();
            return products;
        }
    }
}

