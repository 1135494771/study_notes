using Logging.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //创建DI ServiceCollection对象
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(logBuilder => { 
                //输出到控制台
                logBuilder.AddConsole();
                //设置文件最小输出等级
                logBuilder.SetMinimumLevel(LogLevel.Debug); 
            });
            //注入LogginController 服务对象
            services.AddScoped<LogginController>();
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                var temp = provider.GetRequiredService<LogginController>();
                //执行服务对象方法
                temp.RecordLog();
            }
        }
    }
}
