using System;
using Xunit;
using FluentAssertions;
using Warehouse;

namespace Test.Models
{
  public class ProductTest
  {
    [Fact]
    public void ShouldCreateProduct()
    {
      Product product = new Product(){ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
      product.ProductName.Should().Be("Iphone");
      product.Cost.Should().Be(500.00M);
      product.Weight.Should().Be(7);
      product.Quantity.Should().Be(1);
    }

    [Fact]
    public void ShouldCreateProductFromDto()
    {
      ProductDto productDto = new ProductDto() {ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
      Product newProduct = new Product(productDto);
      newProduct.ProductName.Should().Be("Iphone");
      newProduct.Cost.Should().Be(500.00M);
      newProduct.Weight.Should().Be(7);
      newProduct.Quantity.Should().Be(1);
    }
  }
}