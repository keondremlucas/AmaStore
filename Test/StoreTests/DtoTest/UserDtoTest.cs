using System;
using Xunit;
using FluentAssertions;
using Store;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class UserDtoTest
    {
        [Fact]
         public void ShouldCreateUserFromDto()
        {   

            UserDto dto = new UserDto() {Name = "One"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().NotThrow();
        }

        [Fact]
          public void ShouldFailtoCreateUserFromDto()
        {   
             UserDto dto = new UserDto() {Name = "On"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("The field Name must be a string or array type with a minimum length of '3'."));
          
        }
    }
}