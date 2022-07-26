using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Controller
{
    internal class NLogginController
    {
        //一般默认 ILogger<当前类>
        private readonly ILogger<NLogginController> logger;

        //使用构造函数方式注入 ILogger对象
        public NLogginController(ILogger<NLogginController> _logger)
        {
            this.logger = _logger;
        }

        public void RecordLog()
        {
            logger.LogDebug("调试日志");
            logger.LogError("错误日志");
            logger.LogInformation("信息日志");
            logger.LogWarning("警告日志");
        }

    }
}
