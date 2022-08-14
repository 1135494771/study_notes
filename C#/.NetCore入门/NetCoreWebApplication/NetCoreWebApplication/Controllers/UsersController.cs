using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreWebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet(Name = "aaa")]
        [ActionName("aaa")]
        public string Get()
        {
            return "ok";
        }

        [HttpGet("{id:int}")]
        [ActionName("bbb")]
        public string GetAll(int id)
        {
            return $"id={id}";
        }
    }
}
