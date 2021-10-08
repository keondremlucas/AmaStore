using System;
using System.Collections.Generic;
namespace Store
{
    public class Cart
    {
        public int Id {get; set;}
        public List<Product> Products {get; set;}
        public decimal Cost {get; set;}

    }
}