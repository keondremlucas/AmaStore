using System;
namespace Store
{
    public class Message

    {
        public int Id { get; set;}

        public string From { get; set;}

        public string To {get; set;}

        public string Text {get; set;}
             public Message()
        {

        }

        public Message(MessageDto message)
        {
            Id = new();
            From = message.From;
            To = message.To;
            Text = message.Text;
          
        }

        
    }
    
}
