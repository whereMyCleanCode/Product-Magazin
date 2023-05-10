using System;
using EfLesson.Models;
using EfLesson.ViewModels;
using EfLesson.DAL;

namespace EfLesson.BL.GiveMeMyBasket
{
    public class IdentityBasket : IIdentityBasket
    {
        private ProductDb _productDb;

        public void CreateBasket(List<Product> menu,UserModel user)
        {
            foreach(Product p in menu)
            {
                _productDb.usersbaskets.Add(g => p.)
            }
        }

        public void UpdateBasket(List<MenuViewModel> menu)
        {
        }

        public void UpdateBasket(List<Product> product)
        {
        }
    }
}

