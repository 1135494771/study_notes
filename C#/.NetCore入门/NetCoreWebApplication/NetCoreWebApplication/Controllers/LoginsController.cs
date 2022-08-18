using ClassLibrary1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly class1_test_1 class1_Test_1;

        public LoginsController(class1_test_1 _class1_Test_1)
        {
            this.class1_Test_1 = _class1_Test_1;
        }

        [HttpPost("{id}")]
        public ActionResult<LoginResult> Login(int id, LoginRequest loginReq)
        {
            if (loginReq.UserName == "admin" && loginReq.Password == "123456")
            {
                Console.WriteLine("fdsfs");
                return new LoginResult(true, "登录成功");
            }
            else
            {
                return new LoginResult(false, "登录失败");
            }
        }

        [HttpPost("{i}/{j}")]
        public ActionResult<string> Test(int i, int j)
        {
            int data = class1_Test_1.Add(i, j);
            return data + "";
        }

        public record LoginRequest(string UserName, string Password);

        public record LoginResult(bool result, string data);

    }
}
