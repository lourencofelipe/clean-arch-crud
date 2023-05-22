using CleanArch.Domain.Entities;

namespace CleanArch.Application.Repositories
{
	public interface IProductRepository
	{
		public Product GetById(int id);
		public List<Product> GetAll();
		public void RemoveProduct(int id);
		public Product CreateProduct(Product product);
	}
}
