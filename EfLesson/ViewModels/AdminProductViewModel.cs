using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfLesson.ViewModels
{
	public class AdminProductViewModel
	{
        public bool DeleteProduct { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductCategory { get; set; }

        public int ProductCount { get; set; }

        public string ProductPhoto { get; set; }
    }
}

