using System;
using Xunit;
using FluentAssertions;
using Store;

namespace Test
{
    public class MessageTest
    {
        [Fact]
        public void ShouldMessage()
        {
            Message newMessage = new Message() {From = "User1", To= "User2", Text ="Hello"};
            newMessage.From.Should().Be("User1");
            newMessage.To.Should().Be("User2");
            newMessage.Text.Should().Be("Hello");
        }
        
    }
}
