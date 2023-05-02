using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
	public class BasketModel
	{
		[Key]
		public int BasketId { get; set; }

        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public List<UserModel> UserModels { get; set; } = null!;

        [ForeignKey("Product")]
		public List<int> ProductsId { get; set; } = null!;
		public List<Product> ProductsFromBasket { get; set; } = null!;
	}
}

