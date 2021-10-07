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

    public async Task AddToCartAsync(int userId)
    {
      var client = new HttpClient();


    }
    public async Task SaveAsync()
    {
      await _db.SaveChangesAsync();
    }

  }



}

