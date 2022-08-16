using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        [HttpPost("{id}")]
        public ActionResult<LoginResult> Login(int id, LoginRequest loginReq)
        {
            if (loginReq.UserName == "admin" && loginReq.Password == "123456")
            {
                return new LoginResult(true, "登录成功");
            }
            else
            {
                return new LoginResult(false, "登录失败");
            }
        }

        public record LoginRequest(string UserName, string Password);

        public record LoginResult(bool result, string data);

    }
}
