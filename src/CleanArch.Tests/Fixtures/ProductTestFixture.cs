using CleanArch.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using CleanArch.Persistence.Context;
using CleanArch.Domain.Entities;

namespace CleanArch.Tests.Fixtures;
public class ProductTestFixture : IDisposable
{
    public Product MainProduct { get; private set; }
    public ProductRepository ProductRepository { get; private set; }
    public EfContext Context { get; private set; }

    public ProductTestFixture()
    {
        ConfigureDatabase();
    }

    private void ConfigureDatabase()
    {
        var options = new DbContextOptionsBuilder<EfContext>()
            .UseInMemoryDatabase(databaseName: $"TestDb_{Guid.NewGuid()}")
            .Options;

        Context = new EfContext(options);
        ProductRepository = new ProductRepository(Context);

        ResetDatabase();
    }

    public void ResetDatabase() 
    {
        Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();

        MainProduct = new Product
        {
            ID = Guid.NewGuid(),
            Name = "Keyboard test product",
            Price = 150
        };

        Context.Product.Add(MainProduct);
        Context.SaveChanges();
    }

    public void Dispose()
    {
        // Remove the DB after finish the test execution.
        Context.Database.EnsureDeleted(); 
        Context.Dispose();
    }
}
