using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApi
{
    public interface IMessenger // handles messages
    {
        bool WriteContent(); // all messengers write content
        string ReadContent(); // all messengers read content
    }
}