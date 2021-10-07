using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Store
{
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;}
        [JsonIgnore]
        public List<Message> Messages {get; set;} = new List<Message>();
        [JsonIgnore]
        public Cart Cart {get; set;} = new Cart();
        public User()
        {

        }

        public User(UserDto user)
        {
            Id = new();
            Name = user.Name;
          
        }

        
    }
    

    
}