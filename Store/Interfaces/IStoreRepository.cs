using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
  public interface IStoreRepository
  {
    Task AddUserAsync(User user);
    Task<User> GetUserAsync(int userId);
    Task<Product> AddToCartAsync(int userId, int productId);
    // Task PurchaseCartAsync(int userId);
    Task<IEnumerable<Product>> GetInventoryAsync();
    // Task TransactionHistory(int userId);
    // Task<IActionResult> SendMessagesAsync(Message message);
    // Task<IEnumerable<dynamic>> GetMessagesAsync(Message message);

    Task SaveAsync();
  }
}