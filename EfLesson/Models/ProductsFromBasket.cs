using System;
using System.ComponentModel.DataAnnotations.Schema;
using EfLesson.Models;
namespace EfLesson.Models
{
	[Table("products_from_basekt")]
	public class ProductsFromBasket
	{
		[ForeignKey("Products")]
		[Column("product_id")]
		public int ProductId {get;set;}

		public ProductModel Product { get; set; }


        [ForeignKey("Baskets")]
        [Column("basket_id")]
        public int BasketId { get; set; }

        public BasketModel Basket { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}

