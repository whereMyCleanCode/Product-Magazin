using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
    
	public class UserModel
	{
		[Key]
		public int UserId { get; set; }

		public string Name { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }


        [ForeignKey("OrderModel")]
        public List<int> OrdersId { get; set; } = null!;
        public List<OrderModel> Orders { get; set; } = null!;

        [ForeignKey("BasketModel")]
        public int BasketId { get; set; }
        public List<BasketModel> UserBasket{ get; set; } = null!;
    }
}

