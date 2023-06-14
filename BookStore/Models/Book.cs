using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Category { get; set; }
		[Required]
        [Range(1, 1000)]
        public double Price { get; set; }
		[Required]
		public string? Description { get; set; }
	}
}

