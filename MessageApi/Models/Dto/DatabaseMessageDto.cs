using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public class DatabaseMessageDto : MessageBase 
    {
        public int? id { get; set; } // id of message in the database
        
        public DatabaseMessageDto(){
            this.content = null;
        }
    }
}