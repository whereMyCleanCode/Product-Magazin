using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
	[Table("prodcuts_from_orders")]
	public class ProductsFromOrder
	{
        [ForeignKey("Products")]
        [Column("product_id")]
        public int ProductId { get; set; }

        public ProductModel Product { get; set; }


        [ForeignKey("Orders")]
        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("orders")]
        public OrderModel Order { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}

