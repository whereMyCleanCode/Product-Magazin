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

        public IEnumerable<Product> GetProduct()
        {
            IEnumerable<Product> products = _identityMenuDb.products.ToList();

            return products;
        }

        public IEnumerable<Product> GetProduct(string param)
        {
            IEnumerable<Product> products =  _identityMenuDb.products
                                            .Where(e => e.ProductCategory == param
                                            || e.ProductName == param)
                                            .ToList();
            return products;
        }

        public IEnumerable<Product> GetProduct(int param)
        {
            IEnumerable<Product> products = _identityMenuDb.products
                                          .Where(e => e.ProductPrice == param)
                                          .ToList();
            return products;
        }
    }
}

