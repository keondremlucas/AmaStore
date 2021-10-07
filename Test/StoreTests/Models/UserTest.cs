using System;
using Xunit;
using FluentAssertions;
using Store;

namespace Test
{
    public class UserTest
    {
        [Fact]
        public void ShouldCreateUser()
        {
            User newUser = new User() {Name = "Name"};
            newUser.Name.Should().Be("Name");
            newUser.Cart.Should().NotBeNull();
            newUser.Messages.Should().NotBeNull();
        }

        [Fact]
         public void ShouldCreateUserFromDto()
        {   
            UserDto dto = new UserDto() {Name = "One"};
            User newUser = new User(dto);
            newUser.Name.Should().Be("One");
            newUser.Cart.Should().NotBeNull();
            newUser.Messages.Should().NotBeNull();
        }

        
    }
}
