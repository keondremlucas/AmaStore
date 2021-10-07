using System;
using Xunit;
using FluentAssertions;
using Warehouse;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace Test
{
  public class ProductDtoTest
  {
    [Fact]
    public void ShouldCreateProductFromDto()
    {
      ProductDto productDto = new ProductDto() {ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
      var context = new ValidationContext(productDto);
      Action act = () => Validator.ValidateObject(productDto, context, true);
      act.Should().NotThrow();
    }

    [Fact]
    public void ShouldFailToCreateDtoMinLength()
    {
      ProductDto productDto = new ProductDto() {ProductName = "I", Cost = 500.00M, Weight = 7, Quantity = 1};
      var context = new ValidationContext(productDto);
      Action act = () => Validator.ValidateObject(productDto, context, true);
      act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("minimum length of '2'."));
    }

    [Fact]
    public void ShouldFailToCreateDtoNoCost()
    {
      ProductDto productDto = new ProductDto() {ProductName = "Iphone", Cost = 0, Weight = 7, Quantity = 1};
      var context = new ValidationContext(productDto);
      Action act = () => Validator.ValidateObject(productDto, context, true);
      act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("The field Cost must be between 0.01 and 99999."));
    }

    [Fact]
    public void ShouldFailToCreateDtoNoWeight()
    {
      ProductDto productDto = new ProductDto() {ProductName = "Iphone", Cost = 500.00M, Weight = 0, Quantity = 1};
      var context = new ValidationContext(productDto);
      Action act = () => Validator.ValidateObject(productDto, context, true);
      act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("The field Weight must be between 0.01 and 9999."));
    }

    [Fact]
    public void ShouldFailToCreateDtoNoQuantity()
    {
      ProductDto productDto = new ProductDto() {ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 0};
      var context = new ValidationContext(productDto);
      Action act = () => Validator.ValidateObject(productDto, context, true);
      act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("The field Quantity must be between 1 and 1000."));
    }
  }


}