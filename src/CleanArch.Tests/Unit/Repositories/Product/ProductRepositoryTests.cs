using CleanArch.Tests.Fixtures;
using System.ComponentModel;
using FluentAssertions;
using Xunit;

namespace CleanArch.Tests.Unit.Repositories.Product;

public class ProductRepositoryTests : IClassFixture<ProductTestFixture>
{
    private readonly ProductTestFixture _fixture;
    private static readonly Guid _productId = Guid.NewGuid();

    public ProductRepositoryTests(ProductTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    [Description("Should successfully create a new product in the database.")]
    public void AddProduct_Should_AddProductToDataBase()
    {
        // Arrange
        var product = new CleanArch.Domain.Entities.Product
        {
            ID = Guid.NewGuid(),
            Name = "Laptop Test",
            Price = 20
        };

        // Act
        _fixture.ProductRepository.CreateProduct(product);
        var newProduct = _fixture.Context.Product.Find(product.ID);

        // Assert
        newProduct.Should().NotBeNull();
        newProduct.Name.Should().Be("Laptop Test");
        newProduct.Price.Should().Be(20);
    }

    [Fact]
    [Description("Should return a valid product based on ID.")]
    public void GetProduct_Should_ReturnValidProductById()
    {
        // Arrange
        _fixture.ResetDatabase();
        var product = _fixture.MainProduct;

        // Act
        var retrievedProduct = _fixture.ProductRepository.GetById(product.ID);

        // Assert
        retrievedProduct.Should().NotBeNull();
        retrievedProduct.Name.Should().Be(product.Name);
    }

    [Fact]
    [Description("Should return updated product details.")]
    public void UpdateProduct_Should_ModifyProductDetails()
    {
        // Arrange
        _fixture.ResetDatabase();
        var product = _fixture.MainProduct;

        var productName = "New keyboard Name";
        var productPrice = 100;

        product.Name = productName;
        product.Price = productPrice;

        // Act
        _fixture.ProductRepository.UpdateProduct(product);
        var updatedProduct = _fixture.Context.Product.Find(product.ID);

        // Assert
        updatedProduct.Should().NotBeNull();
        updatedProduct.Name.Should().Be(productName);
        updatedProduct.Price.Should().Be(productPrice);
    }

    [Fact]
    [Description("Should successfully remove the product from database.")]
    public void RemoveProduct_Should_RemoveProductFromDataBase() 
    {
        // Arrange
        _fixture.ResetDatabase();

        // Act
        _fixture.ProductRepository.RemoveProduct(_fixture.MainProduct.ID);
        var removedProduct = _fixture.Context.Product.Find(_fixture.MainProduct.ID);

        // Assert
        removedProduct.Should().BeNull();
    }
}

