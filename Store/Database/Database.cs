using System;
using Microsoft.EntityFrameworkCore;

namespace Store
{
  public class Database : DbContext
  {
      public DbSet<User> Users {get; set;}
      public DbSet<Message> Messages {get; set;}
      public DbSet<Cart> Carts {get; set;}
      public Database(DbContextOptions<Database> options) : base(options) {}  
  }

}