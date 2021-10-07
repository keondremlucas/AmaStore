using System;
using System.Collections.Generic;
namespace Store
{
    public class Cart
    {
        public int Id {get; set;}
        public List<string> Products {get; set;}
        public int Size {get; set;}
        public decimal Cost {get; set;}

    }
}