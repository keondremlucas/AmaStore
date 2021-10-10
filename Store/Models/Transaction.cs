using System;
using System.Collections.Generic;
namespace Store
{
    public class Transaction
    {
        public int Id {get; set;}
        public List<String> Products {get; set;}
        public decimal Cost {get; set;}

    }
}