using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class Message
    {
        public enum MessageType
        {
            Error,
            Warning,
            Information
        }

        private MessageType type;
        private DateTime time;
        private string text;

        public Message(MessageType type, string text)
        {
            this.type = type;
            this.time = DateTime.Now;
            this.text = text;
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            switch (type)
            {
                case MessageType.Error:
                    res.Append("Error: ");
                    break;
                case MessageType.Warning:
                    res.Append("Warning: ");
                    break;
                case MessageType.Information:
                    res.Append("Information: ");
                    break;
            }

            res.Append(time.ToString());
            res.Append(": ");
            res.Append(text);

            return res.ToString();
        }
    }
}
