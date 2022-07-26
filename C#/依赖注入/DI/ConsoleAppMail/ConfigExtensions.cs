using ConfigServices;

namespace Microsoft.Extensions.DependencyInjection
{
    //设置为静态的类
    public static class ConfigExtensions
    {
        //要添加this 关键词，不然. 不出来
        public static void AddConfigServer(this IServiceCollection services)
        {
            services.AddScoped<IConfigServer,ConfigServerImpl>();
        }
    }
}
