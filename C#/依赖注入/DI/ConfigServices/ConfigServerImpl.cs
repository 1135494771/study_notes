using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    public class ConfigServerImpl : IConfigServer
    {
        public string getValue(string name)
        {
            //从环境变量里读取配置
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
