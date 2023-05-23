using System;

namespace CleanArch.Domain.Entities
{
	public class Product
	{
		public Guid ID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
	}
}
