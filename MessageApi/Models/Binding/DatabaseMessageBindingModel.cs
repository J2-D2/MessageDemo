using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public class DatabaseMessageBindingModel // used to bind client's data
    {
        public int? id { get; set; } // id for database message record
        public string content { get; set; } 
    }
}