using CleanArch.Application.Repositories;
using CleanArch.Persistence.Context;
using CleanArch.Domain.Entities;

namespace CleanArch.Persistence.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly EfContext _efContext;

    public ProductRepository(EfContext efContext)
    {
        _efContext = efContext;
    }

    public Product GetById(Guid id)
    {
        var product = _efContext.Product.FirstOrDefault(x => x.ID == id);

        if (product is null)
            throw new Exception("Product not found.");

        return product;
    }

    public List<Product> GetAll()
    {
        var products = _efContext.Product.ToList();

        if (products is null)
            return new List<Product>();

        return products;
    }

    public void RemoveProduct(Guid id)
    {
        var product = _efContext.Product.FirstOrDefault(x => x.ID == id);

        if (product is null)
            throw new Exception("Product not found.");

        _efContext.Product.Remove(product);
        _efContext.SaveChanges();
    }

    public Product CreateProduct(Product product)
    {
        product.ID = Guid.NewGuid();

        _efContext.Product.Add(product);
        _efContext.SaveChanges();

        return product;
    }

    public Product UpdateProduct(Product product)
    {
        var originalProduct = _efContext.Product.FirstOrDefault(x => x.ID == product.ID);

        if (originalProduct is null)
            throw new Exception("Product not found.");

        originalProduct.Name = product.Name;
        originalProduct.Price = product.Price;

        _efContext.Update(originalProduct);
        _efContext.SaveChanges();

        return product;
    }
}
