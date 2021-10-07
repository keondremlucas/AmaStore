using System;
using Xunit;
using FluentAssertions;
using Store;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace Test
{
    public class MessageDtoTest
    {
        [Fact]
         public void ShouldCreateMessageFromDto()
        {   

            MessageDto dto = new MessageDto() {From = "User1", To = "User2", Text = "Hello"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().NotThrow();
        }

        [Fact]
          public void ShouldFailtoCreateDTOFromLength()
        {   
            MessageDto dto = new MessageDto() {From = "U1", To = "User2", Text = "Hello"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("The field From must be a string or array type with a minimum length of '3'."));
          
        }
         [Fact]
          public void ShouldFailtoCreateDTOToLength()
        {   
            MessageDto dto = new MessageDto() {From = "User1", To = "U2", Text = "Hello"};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("The field To must be a string or array type with a minimum length of '3'."));
          
        }

          [Fact]
          public void ShouldFailtoCreateDTONoText()
        {   
            MessageDto dto = new MessageDto() {From = "User1", To = "User2", Text = ""};
            var context = new ValidationContext(dto);
            Action act = () => Validator.ValidateObject(dto, context, true);
            act.Should().Throw<ValidationException>().Where(e => e.Message.Contains("The Text field is required"));
          
        }
    }
}