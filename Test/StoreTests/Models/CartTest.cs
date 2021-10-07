using System;
using Xunit;
using FluentAssertions;
using Store;

namespace Test
{
    public class CartTest
    {
        [Fact]
        public void ShouldCreateCart()
        {
            Cart Cart = new Cart();
            Cart.Should().NotBeNull();
            
        }
        [Fact]
        public void ShouldCreateCartFromUser()
        {
            User newUser = new User() {Name = "Name"};
            newUser.Name.Should().Be("Name");
            newUser.Cart.Should().NotBeNull();
            newUser.Messages.Should().NotBeNull();
        }

    

        
    }
}