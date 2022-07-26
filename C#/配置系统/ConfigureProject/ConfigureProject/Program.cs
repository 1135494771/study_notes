using ConfigureProject.Controller;
using ConfigureProject.Module;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConfigureProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NewMethod();

            //NewMethod2();
        }

        #region 读取配置原始方法
        /*读取配置原始方法 */
        private static void NewMethod()
        {
            //创建一个ConfigurationBuilder对象
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //读取ConfigFolder 文件夹下 config.json
            configurationBuilder.AddJsonFile("ConfigFolder/config.json", optional: true, reloadOnChange: true);
            //创建IConfigurationRoot对象
            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            //读取普通的属性
            string name = configurationRoot["name"];
            Console.WriteLine($"name:{name}");
            Console.WriteLine($"=================");
            //读取 info对象下的属性值
            string age = configurationRoot.GetSection("info:age").Value;
            Console.WriteLine($"info.age:{age}");
            Console.WriteLine($"=================");
            //将读取到的 json对象转为实体，并读取属性值
            Info info = configurationRoot.GetSection("info").Get<Info>();
            Console.WriteLine($"info.age:{info.age}");
            Console.WriteLine($"info.sex:{info.sex}");
            Console.WriteLine($"info.hobyy:{string.Join("||", info.hobyy)}");
            Console.ReadKey();
        }
        #endregion

        #region 选项方式读取配置
        /*选项方式读取配置*/
        private static void NewMethod2()
        {
            //使用DI 依赖注入方法读取配置
            ServiceCollection services = new ServiceCollection();
            //添加服务对象
            services.AddScoped<OptionReadController>();
            //创建一个ConfigurationBuilder对象
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //读取ConfigFolder 文件夹下 config.json
            configurationBuilder.AddJsonFile("ConfigFolder/config.json", optional: true, reloadOnChange: true);
            //创建IConfigurationRoot对象
            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            //绑定Config 到 IConfigurationRoot上
            services.AddOptions().Configure<Config>(e => configurationRoot.Bind(e));
            using (ServiceProvider provider = services.BuildServiceProvider())
            {
                while (true)
                {
                    using (IServiceScope scope = provider.CreateScope())
                    {
                        var temp = scope.ServiceProvider.GetRequiredService<OptionReadController>();
                        temp.Test();
                    }
                }
            }
        }
        #endregion
    }
}
