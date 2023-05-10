using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EfLesson.Models;

namespace EfLesson.ViewModels
{
	public class MenuViewModel
	{
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductCategory { get; set; }

        public string ProductPhoto { get; set; }
    }
}

