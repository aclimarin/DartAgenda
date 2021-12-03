using System.Collections.Generic;

namespace DarAgenda.Utils.Models
{
    public class DefaultResponse
    {
        public DefaultResponse()
        {
            
        }
        public DefaultResponse(List<string> messages, object data)
        {
            Messages = messages;
            Data = data;
        }

        public DefaultResponse(string message, object data)
        {
            Messages = new List<string>();
            Messages.Add(message);
            Data = data;
        }

        public List<string> Messages { get; set; }
        public object Data { get; set; }
    }
}
