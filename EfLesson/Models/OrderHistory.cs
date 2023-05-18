using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.Models
{
	[Table("order_history")]
	public class OrderHistory
	{
		[Key]
		[Column("order_id")]
		public List<int> OrderId { get; set; }

		[Column("order_date")]
		public DateTime Date { get; set; }
	}
}

