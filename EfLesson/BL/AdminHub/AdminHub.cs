using System;
using EfLesson.DAL;
using EfLesson.BL.Crypro;
using EfLesson.Models;
using System.Linq;
using EfLesson.ViewModels;

namespace EfLesson.BL.AdminHub
{
    public class AdminHub : IAdminHub
    {
        private ProductDb _context;
        private ICrypto _crypto;

        public AdminHub(ProductDb context,ICrypto crypto)
        {
            _context = context;
            _crypto = crypto;
        }


        public void AddOrUpdateProduct(AdminProductViewModel product)
        {
            Product modifiedProduct = new Product();

            if (_context.products
                .Select(p => p.ProductName == product.ProductName)
                              == null)
             {
                _context.Add(new Product
                {
                    ProductName = product.ProductName,
                    ProductCategory = product.ProductCategory,
                    ProductCount = product.ProductCount,
                    ProductPrice = product.ProductPrice
                });
             }
             else
              {
                modifiedProduct = _context.products
                    .Where(p => p.ProductName == product.ProductName)
                    .FirstOrDefault() ?? new Product();
              }


            _context.SaveChanges();
        }


        public void DeleteProduct(AdminProductViewModel product)
        {
            _context.products.Remove
                (_context.products
                .FirstOrDefault(p => p.ProductName == product.ProductName));

            _context.SaveChanges();
        }

    }
}

