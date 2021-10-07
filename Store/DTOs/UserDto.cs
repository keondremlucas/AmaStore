using System;
using System.ComponentModel.DataAnnotations;
namespace Store
{
    public class UserDto
    {
        [Required]
        [MinLength(3)]
        public string Name {get; set;}
    }
}