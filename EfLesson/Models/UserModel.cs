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
        public int Id { get; set; }

        [Column("user_name")]
        public string Name { get; set; }

        [Column("user_phone")]
        public int PhoneNumber { get; set; }

        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("password")]
        public string Password { get; set; } = null!;

        [Column("salt")]
        public string Salt { get; set; } = null!;

        [Column("user_address")]
        public string Address { get; set; }

        public BasketModel Basket { get; set; }

        public List<OrderModel> Orders { get; set; }

    }
}

