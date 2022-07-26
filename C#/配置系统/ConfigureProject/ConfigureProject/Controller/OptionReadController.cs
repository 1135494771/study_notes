using ConfigureProject.Module;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureProject.Controller
{
    /// <summary>
    /// 使用DI 注入方式，读取选项配置
    /// </summary>
    class OptionReadController
    {
        private readonly IOptionsSnapshot<Config> optionsSnapshot;

        public OptionReadController(IOptionsSnapshot<Config> _optionsSnapshot)
        {
            this.optionsSnapshot = _optionsSnapshot;
        }

        public void Test()
        {
            Console.WriteLine(optionsSnapshot.Value.name);
            Console.WriteLine("*******************");
            Console.WriteLine(optionsSnapshot.Value.info.age);
            Console.WriteLine("按任意键继续");
            Console.ReadKey();
        }
    }
}
