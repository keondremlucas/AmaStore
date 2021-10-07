using System;

namespace Warehouse
{
    public class Product
    {
        public int Id { get; set;}
        public string ProductName { get; set;}
        public decimal Cost { get; set;}
        public double Weight { get; set;}
        public int Quantity { get; set;}
         
         public Product(){}
         public Product(ProductDto productDto)
         {
             Id = new();
             ProductName = productDto.ProductName;
             Cost = productDto.Cost;
             Weight = productDto.Weight;
             Quantity = productDto.Quantity; 
         }
    }

}