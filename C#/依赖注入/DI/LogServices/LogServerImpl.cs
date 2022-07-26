using System;
using System.Collections.Generic;
using System.Text;

namespace LogServices
{
    public class LogServerImpl : ILogServer
    {
        public void logError(string msg)
        {
            Console.WriteLine($"Error:{msg}");
        }

        public void logInfo(string msg)
        {
            Console.WriteLine($"Info:{msg}");
        }

        public void logWarning(string msg)
        {
            Console.WriteLine($"Warning:{msg}");
        }
    }
}
