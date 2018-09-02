using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public class AppSettings  // will store the app settings for the application
    {
        public string Environment { get; set; }
        public string DBConnectionString { get; set; }
    }
}