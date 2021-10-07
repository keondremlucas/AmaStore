using System;
using System.ComponentModel.DataAnnotations;
namespace Store
{
    public class MessageDto
    {
        [Required]
        [MinLength(3)]
        public string From {get; set;}
        [Required]
        [MinLength(3)]
        public string To {get; set;}
        [Required]
        public string Text {get; set;}
    }
}