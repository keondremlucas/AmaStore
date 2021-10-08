// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace Store
// {
//   public interface IStoreRepository
//   {
//     Task AddUserAsync(User user);
//     Task<User> GetUserAsync(UserId userId);
//     Task AddToCartAsync(UserId userId, ProductId productId);
//     Task PurchaseCartAsync(UserId userId);
//     Task GetInventoryAsync();
//     Task TransactionHistory(UserId userId);
//     Task<IActionResult> SendMessagesAsync(Message message);
//     Task<IEnumerable<dynamic>> GetMessagesAsync(Message message);

//     Task SaveAsync();
//   }
// }