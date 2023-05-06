using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
    [Table("orders")]
	public class OrderModel
	{
        [Key]
        [Column("order_id")]
		public string  OrderId { get; set; }

        [Column("order_star_time")]
        public DateTime OrderStartTime { get; set; }

        [Column("order_end_time")]
        public DateTime OrderEndTime { get; set; }

        [Column("orders_state")]
        public bool OrderState { get; set; }

      
        [ForeignKey("Product")]
        [Column("fk_products_id_from_order")]
        public List<int> ProductsId { get; set; }
        [Column("fk_products_from_order")]
        public List<Product> ProductsFromOrder { get; set; }

       
        [ForeignKey("UserModel")]
        [Column ("fk_user_id_for_basket")]
        public int UserId { get; set; }
        [Column("fk_users_from_order")]
        public UserModel User { get; set; }

    }
}

