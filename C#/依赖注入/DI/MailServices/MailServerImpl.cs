using ConfigServices;
using LogServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailServices
{
    public class MailServerImpl : IMailServer
    {
        private readonly IConfigServer configServer;
        private readonly ILogServer logServer;

        public MailServerImpl(IConfigServer _configServer, ILogServer _logServer)
        {
            this.configServer = _configServer;
            this.logServer = _logServer;
        }


        public void sendMail(string content)
        {
            logServer.logInfo("开始发送邮件");
            string envConfig = configServer.getValue("Path");
            Console.WriteLine($"环境配置：{envConfig}");
            Console.WriteLine($"开始发送邮件：{content}");
            logServer.logInfo("发送邮件结束");
        }
    }
}
