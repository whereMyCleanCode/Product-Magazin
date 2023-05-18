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
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        public UserModel User {get;set;}

        [Column("products_from_basekt")]
        public List<ProductsFromBasket> ProductsFromBaskets { get; set; }

    }
}

