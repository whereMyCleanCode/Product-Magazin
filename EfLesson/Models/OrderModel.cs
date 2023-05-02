using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
	public class OrderModel
	{
        [Key]
		public string  OrderId { get; set; }

        public DateTime OrderStartTime { get; set; }

        public DateTime OrderEndTime { get; set; }

        public  bool OrderState { get; set; }


        [ForeignKey("UserModel")]
        public int UserId { get; set; } 
        public List<UserModel> Users { get; set; } = null!;

        [ForeignKey("Product")]
        public List<int> ProductsId { get; set; } = null!;
        public List<Product> ProductsFromOrder { get; set; } = null!;
    }
}

