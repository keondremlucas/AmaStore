using System;
using System.ComponentModel.DataAnnotations;

namespace Warehouse
{
  public class ProductDto
  {
    [Required]
    [MinLength(2)]
    public string ProductName {get; set;}
    [Required]
    [Range(0.01, 99999)]
    public decimal Cost {get; set;}
    [Required]
    [Range(0.01, 9999)]
    public double Weight {get; set;}
    [Required]
    [Range(1,1000)]
    public int Quantity {get; set;}
  }
}