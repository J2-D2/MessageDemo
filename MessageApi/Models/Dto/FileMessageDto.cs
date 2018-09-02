using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public class FileMessageDto : MessageBase 
    {
        public string fileName { get; set; } 
        public string filePath { get; set; } 
        
        public FileMessageDto(){
            this.content = null;
        }
    }
}