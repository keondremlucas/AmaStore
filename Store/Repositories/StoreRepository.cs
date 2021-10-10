using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Json;

namespace Store
{
  public class StoreRepository : IStoreRepository
  {
    private Database _db;
    public StoreRepository(Database db)
    {
      _db=db;
    }
    public async Task AddUserAsync(User user)
    {
      await _db.AddAsync(user);
    }
    public async Task<User> GetUserAsync(int userId)
    {
      return await _db.Users.Where(u => u.Id == userId)
      .Include(u => u.Cart)
      .SingleOrDefaultAsync();
    }

    public async Task<Product> AddToCartAsync(int userId, int productId)
    {
      var client = new HttpClient();
      Product product = null;

      try
      {
        var newProductsAdded = await client.GetFromJsonAsync<ProductDto>($"http://localhost:5000/api/warehouse/product?productId={productId}");
        product = new Product() {ProductName = newProductsAdded.ProductName, Cost = newProductsAdded.Cost};
        
        var cartInfo = _db.Carts.Where(cart => cart.Id == userId).Include(c => c.Products).SingleOrDefault();
        Console.WriteLine($"{cartInfo.Cost}");
        cartInfo.Products.Add(product);
        cartInfo.Cost += product.Cost;
        Console.WriteLine($"{cartInfo.Cost}");
        Console.WriteLine($"{cartInfo.Products.Count()}");
        await _db.AddAsync(product);
        await _db.SaveChangesAsync();
      }
      catch(Exception ex)
      {
        Console.WriteLine($"Error : {ex.Message}");
      }
      return product;
    }

    public async Task<IEnumerable<Product>> GetInventoryAsync(){
      var client = new HttpClient();
      List<Product>products=new();
      var productsfound= await client.GetFromJsonAsync<List<Product>>($"http://localhost:5000/api/warehouse/products");

      return productsfound;

    }
    public async Task SaveAsync()
    {
      await _db.SaveChangesAsync();
    }

  }

}

