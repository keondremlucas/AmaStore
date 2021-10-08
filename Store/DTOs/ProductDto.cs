using System.ComponentModel.DataAnnotations;

namespace Store
{
  public record ProductDto(int Id, string ProductName, decimal Cost);
}