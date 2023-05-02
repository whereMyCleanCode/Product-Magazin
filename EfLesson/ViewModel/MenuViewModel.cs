using System;
using System.ComponentModel.DataAnnotations;
using EfLesson.Models;

namespace EfLesson.ViewModel
{
	public class MenuViewModel
	{
		public IEnumerable<Product> products { get; set; }

	}
}

