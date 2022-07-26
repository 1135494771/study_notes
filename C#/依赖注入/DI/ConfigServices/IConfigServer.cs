using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    public interface IConfigServer
    {
        string getValue(string name);
    }
}
