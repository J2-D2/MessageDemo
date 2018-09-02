using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public class FileMessageBindingModel  // used to bind client's data
    {
        public string fileName { get; set; } 
        public string filePath { get; set; } 
        public string content { get; set; } 
    }
}