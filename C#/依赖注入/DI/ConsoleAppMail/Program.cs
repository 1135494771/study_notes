using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppMail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //通过注册类型为接口；实现类型为具体的类
            services.AddScoped<IConfigServer, ConfigServerImpl>();
            //可以通过指定类的类对象
            services.AddScoped(typeof(IConfigServer), typeof(ConfigServerImpl));
            //扩展自定义注册类名
            services.AddConfigServer();
            services.AddScoped<ILogServer, LogServerImpl>();
            services.AddScoped<IMailServer, MailServerImpl>();
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                IMailServer mailServer = provider.GetRequiredService<IMailServer>();
                mailServer.sendMail("邮箱内容为AAA");
            }
        }
    }
}
