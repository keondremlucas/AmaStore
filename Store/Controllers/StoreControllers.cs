using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace Store
{

  [ApiController]
  [Route("api/store")]
  public class StoreController : ControllerBase
  {

    private IStoreRepository _repository;

    public StoreController(IStoreRepository repository)
    {
      _repository = repository;
    }

    [HttpPost("newuser")]
    public async Task<IActionResult> NewUser(UserDto userDto)
    {
      var user = new User(userDto);
      await _repository.AddUserAsync(user);
      await _repository.SaveAsync();

      return CreatedAtAction("GetOneUser", new {user.Id}, user);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetOneUser(int userId)
    {
      var user = await _repository.GetUserAsync(userId);
      return Ok(user);
    }

    [HttpPatch("user/addtocart")]
    public async Task<IActionResult> AddToCart(int userId, int productId)
    {
      var productAdded = await _repository.AddToCartAsync(userId, productId);
      return Ok(productAdded.ProductName);
    }



  }
}