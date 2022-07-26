using System;
using System.Collections.Generic;
using System.Text;

namespace LogServices
{
    public interface ILogServer
    {
        void logInfo(string content);

        void logWarning(string content);

        void logError(string content);
    }
}
