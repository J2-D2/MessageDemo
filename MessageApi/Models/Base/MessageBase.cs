using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public class MessageBase // base for all messages
    {
        public string content { get; set; } // all messages should have content            
    }
}