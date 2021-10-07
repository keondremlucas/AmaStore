using System;
using System.Collections.Generic;
namespace Store
{
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<Message> Messages {get; set;} = new List<Message>();
        public Cart Cart {get; set;}


        
    }
}