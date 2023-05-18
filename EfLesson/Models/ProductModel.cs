  using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EfLesson.DAL;
using Microsoft.EntityFrameworkCore;

namespace EfLesson.Models
{
    [Table("products")]
    public class ProductModel
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("product_price")]
        public int ProductPrice { get; set; }

        [Column("product_category")]
        public string ProductCategory { get; set; }

        [Column("product_count")]
        public int ProductCount { get; set; }

        [Column("product_photo")]
        public string ProductPhoto { get; set; }

        [Column("products_from_basket")]
        public List<ProductsFromBasket> ProductsFromBaskets { get; set; }

        [Column("products_from_orders")]
        public List<ProductsFromOrder> ProductsFromOrders { get; set; }

    }
}

