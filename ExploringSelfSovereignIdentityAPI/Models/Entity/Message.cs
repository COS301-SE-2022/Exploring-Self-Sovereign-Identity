using System;

namespace ExploringSelfSovereignIdentityAPI.Models.Entity
{
    [Serializable]
    public class Message
    {
        public string Value { get; }

        public Message(string value)
        {
            Value = value;
        }
    }
}
