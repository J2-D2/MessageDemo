using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public class FileMessengerModel : IMessenger // writes and reads messages/ data from a local file
    {  
        public FileMessageDto message { get; set; }

        public bool WriteContent(){
            // write content to a file
            return true;
        }

        public string ReadContent(){ // reads contents of a file
            var path = message.filePath;
            // read content from a file
            return "hello world"; // return data
        }

        public FileMessengerModel(string fileName, string filePath){ // constructor for reading content
            message = new FileMessageDto();
            message.fileName = fileName;
            message.filePath = filePath;
            message.content = null;
        }

        public FileMessengerModel(string fileName, string filePath, string content){ // constructor for writing content
            message = new FileMessageDto();
            message.fileName = fileName;
            message.filePath = filePath;
            message.content = content;
        }
        
    }
}