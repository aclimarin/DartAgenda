using System;
using System.Collections.Generic;

namespace DarAgenda.Utils.Extensions
{
    public class ExceptionExtension: Exception
    {
        public List<string> Messages { get; }
        public ExceptionExtension(List<string> messages)
        {
            Messages = messages;
        }

        public ExceptionExtension(string message)
        {
            Messages = new List<string>();
            Messages.Add(message);
            Messages.Add(this.Message);
        }
    }
}
