using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("user_name")]
        public string Name { get; set; }

        [Column("user_phone")]
        public int PhoneNumber { get; set; }

        [Column("user_address")]
        public string Address { get; set; }

        [ForeignKey("OrderModel")]
        [Column("fk_order_for_user_id_from_orders")]
        public List<int> OrdersId { get; set; }
        [Column("fk_product_from_orders")]
        public List<OrderModel> Orders { get; set; } = null!;

    }
}

