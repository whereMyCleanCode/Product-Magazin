using System;
using EfLesson.Models;
using EfLesson.ViewModels;
using EfLesson.DAL;

namespace EfLesson.BL.GiveMeMyBasket
{
    public class IdentityBasket : IIdentityBasket
    {
        private ProductDb _productDb;

        public void CreateBasket(List<ProductModel> menu,int userid)
        {
            foreach(ProductModel product in menu)
            {
               
            }
        }

        public void UpdateBasket(List<MenuViewModel> menu)
        {
        }

        public void UpdateBasket(List<ProductModel> product)
        {
        }
    }
}

