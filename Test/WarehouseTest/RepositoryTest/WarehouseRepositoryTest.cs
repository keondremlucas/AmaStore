
using System;
using Xunit;
using FluentAssertions;
using Lib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Warehouse;
using System.Threading.Tasks;

namespace Test
{
  public class WarehouseRepositoryTest
  {

    private Database _db;
    private IWarehouseRepository _repo;
    public WarehouseRepositoryTest()
    {
      var conn = new SqliteConnection("DataSource=:memory:");
      conn.Open();
      var options = new DbContextOptionsBuilder<Database>().UseSqlite(conn).Options;
      _db = new Database(options);
      _db.Database.EnsureDeleted();
      _db.Database.EnsureCreated();
      _repo = new WarehouseRepository(_db);
    }


    [Fact]
    public async Task ShouldSaveProductToDatabase()
    {
      Product product = new Product(){ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
       await _repo.AddProductAsync(product);
       await _repo.SaveAsync();
       _db.Products.Count().Should().Be(1);
    }

    [Fact]
    public async Task ShouldUpdateProductInDatabase()
    { 
      Product product = new Product(){ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
      await _repo.AddProductAsync(product);
      await _repo.SaveAsync();
      _repo.UpdateProduct(product, 2);
      await _repo.SaveAsync();
      _db.Products.FirstOrDefault().Quantity.Should().Be(2);


    }

    [Fact]
    public async Task ShouldGetAProductById()
    {
      Product product = new Product(){ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
      await _repo.AddProductAsync(product);
      await _repo.SaveAsync();
      var productId = _db.Products.FirstOrDefault().Id;
      var fetchedproduct = await _repo.GetOneProductAsync(productId);
      fetchedproduct.ProductName.Should().Be("Iphone");


    }

    [Fact]
    public async Task ShouldGetAllProductsFromTheDatabase()
    {
      Product product1 = new Product(){ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
       Product product2 = new Product(){ProductName = "Fridge", Cost = 500.00M, Weight = 600, Quantity = 1};
      await _repo.AddProductAsync(product1);
      await _repo.AddProductAsync(product2);
      await _repo.SaveAsync();
      var allproducts = await _repo.GetAllProductsAsync();
      allproducts.Should().HaveCount(2);


    }
    [Fact]
    public async Task ShouldGetAProductsQuantity()
    {
      Product product1 = new Product(){ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
      await _repo.AddProductAsync(product1);
      await _repo.SaveAsync();
      var quanity = _repo.CheckProductQuantity(product1);
      quanity.Should().Be(1);


    }

    [Fact]
    public async Task ShouldCheckIfProductExists()
    {
      Product product1 = new Product(){ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
      await _repo.AddProductAsync(product1);
      await _repo.SaveAsync();
      var exists = _repo.CheckProductExists(product1);
      exists.Should().Be(2);


    }
  }
}