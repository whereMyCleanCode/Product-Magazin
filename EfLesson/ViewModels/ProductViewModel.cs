using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.ViewModels
{
	public class ProductViewModel
	{
        public string ProductName { get; set; }

        public int? ProductPrice { get; set; }

        public string ProductCategory { get; set; }

        public string ProductPhoto { get; set; }
    }
}

