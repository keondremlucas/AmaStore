using System;

namespace Store
{
    public class Product
    {
        public int Id { get; set;}
        public string ProductName { get; set;}
        public decimal Cost { get; set;}
         
         public Product(){}
         public Product(ProductDto productDto)
         {
             Id = new();
             ProductName = productDto.ProductName;
             Cost = productDto.Cost;
         }

         public override string ToString(){
             var returnval=$"Product Name: {ProductName} Product Cost: ${Cost}";
             return returnval;
         }
    }

}