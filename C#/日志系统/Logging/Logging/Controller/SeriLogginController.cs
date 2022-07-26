using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Controller
{
    internal class SeriLogginController
    {
        private readonly ILogger<SeriLogginController> logging;

        public SeriLogginController(ILogger<SeriLogginController> _logging)
        {
            this.logging = _logging;
        }

        public void WriteSerilog()
        {
            logging.LogDebug("测试 Debug");
            logging.LogInformation("测试 Information");
            logging.LogWarning("测试 Warning");
            logging.LogError("测试 Error");

            User user = new User() { Id = 1, Name = "cqx" };
            logging.LogInformation("自定义格式化日志{@user}", user);
        }

    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
