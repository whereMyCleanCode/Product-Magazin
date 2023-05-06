using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
    [Table("baskets")]
    public class BasketModel
	{
		[Key]
        [Column("basket_id")]
        public int BasketId { get; set; }

        [ForeignKey("Product")]
        [Column("fk_product_id")]
        public List<int> ProductId { get; set; }
        [Column("fk_froducts_from_basket_id")]
        public List<Product> ProductsFromBasket { get; set; } = null!;

        [ForeignKey("UserModel")]
        [Column("fk_user_id")]
        public int UserId { get; set; }

        [Column("fk_basket_for_user")]
        public UserModel UserModel { get; set; }
	}
}

