using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApplication.Services;

namespace NetCoreWebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly UserService userService;

        //public UsersController(UserService _userService)
        //{
        //    this.userService = _userService;
        //}

        //[HttpGet("{i}/{j}")]
        //[ActionName("Add")]
        //public ActionResult<int> Add(int i, int j)
        //{
        //    return userService.Add(i, j);
        //}

        //把 [FromServices] 服务当成参数注入
        [HttpGet("{i}/{j}")]
        [ActionName("Add")]
        public ActionResult<int> Add([FromServices] UserService userService, int i, int j)
        {
            return userService.Add(i, j);
        }

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

        [HttpGet("{id:int}")]
        [ActionName("GetAll")]
        public IActionResult GetAllTest(int id)
        {
            if (id == 1)
            {
                return Ok($"id={id}");
            }
            else
            {
                return NotFound($"id={id},id输入错误");
            }
        }

        
    }
}
