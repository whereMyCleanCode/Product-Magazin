using System;
using EfLesson.DAL;

using EfLesson.Models;

namespace EfLesson.BL.AdminHub
{
    public class AdminHub : IAdminHub
    {
        private ProductDb _context;

        public AdminHub(ProductDb context)
        {
            _context = context;
        }

        public void AddOrUpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateProduct(string name)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdateProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            _context.productscatalog.Add(product);
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(string name)
        {
            throw new NotImplementedException();
        }
    }
}

