using Logging.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;

namespace Logging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NLog();

            Serilog();
        }


        #region NLog
        private static void NLog()
        {
            //创建DI ServiceCollection对象
            ServiceCollection services = new ServiceCollection();
            services.AddLogging(logBuilder =>
            {
                //添加Nlog配置
                logBuilder.AddNLog();
            });
            //注入LogginController 服务对象
            services.AddScoped<NLogginController>();
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                var temp = provider.GetRequiredService<NLogginController>();
                //执行服务对象方法
                temp.RecordLog();
            }
        }
        #endregion

        #region Serilog
        private static void Serilog()
        {
            //创建DI ServiceCollection对象
            ServiceCollection services = new ServiceCollection();
            //SeriLogginController 服务对象
            services.AddScoped<SeriLogginController>();
            services.AddLogging(logBuilder =>
            {
                //链式变成设置Serilog配置
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console(new JsonFormatter())
                .CreateLogger();
                //注入Serilog
                logBuilder.AddSerilog();
            });
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                var temp= provider.GetRequiredService<SeriLogginController>();
                temp.WriteSerilog();
            }
        }
        #endregion
    }
}
