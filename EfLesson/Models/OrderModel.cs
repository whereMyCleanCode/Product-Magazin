using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EfLesson.Models;

namespace EfLesson.Models
{
    [Table("orders")]
	public class OrderModel
	{
        [Key]
        [Column("order_id")]
		public int Id { get; set; }

        [Column("order_star_time")]
        public DateTime OrderStartTime { get; set; }

        [Column("order_end_time")]
        public DateTime OrderEndTime { get; set; }

        [Column("orders_state")]
        public bool OrderState { get; set; }

        [Column("count_of_product")]
        public int CountOfProduct { get; set; }

        [ForeignKey("User")]
        [Column("fk_user_id")]
        public int UserId { get; set; }

        public UserModel User { get; set; }

        [Column("products_from_orders")]
        public List<ProductsFromOrder> ProductsFromOrders { get; set; }
    }
}

