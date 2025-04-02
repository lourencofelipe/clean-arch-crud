using CleanArch.Domain.Entities;

namespace CleanArch.Application.Repositories;
public interface IProductRepository
{
    public Product GetById(Guid id);
    public List<Product> GetAll();
    public void RemoveProduct(Guid id);
    public Product CreateProduct(Product product);
    public Product UpdateProduct(Product product);
}
