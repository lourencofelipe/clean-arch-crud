using CleanArch.Application.Repositories;
using CleanArch.Persistence.Context;
using CleanArch.Domain.Entities;

namespace CleanArch.Persistence.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly EfContext _efContext;

		public ProductRepository(EfContext efContext)
		{
			_efContext = efContext;
		}

		public Product GetById(int id)
		{
			var product = _efContext.Product.FirstOrDefault(x => x.ID == id);

			if (product is null)
				throw new Exception("Product not found.");
			else
				return product;
		}

		public List<Product> GetAll() 
		{
			var products = _efContext.Product.ToList();

			if (products is null)
				return new List<Product>();	
			else
				return products;
		}

		public void RemoveProduct(int id)
		{
			var product = _efContext.Product.FirstOrDefault(x => x.ID == id);

			if (product is null)
				throw new Exception("Product not found.");
			
			_efContext.Product.Remove(product);
			_efContext.SaveChanges();
		}

		public Product CreateProduct(Product product)
		{
			var products = _efContext.Product.ToList();
			product.ID = products.Count + 1;

			_efContext.Product.Add(product);
			_efContext.SaveChanges();

			return product;
		}
	}
}
