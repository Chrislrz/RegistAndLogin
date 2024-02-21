using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Service;
using Service.Dto;
using Table;

namespace LoginAndRegist.Controllers;


[ApiController]
[Route("[controller]/[Action]")]

public class RegistController : Controller
{
    private readonly IUserService _userService;
    
    public RegistController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost]
    public ActionResult<newusers> RegistUser([FromBody] RegistDto input)
        //service就只写服务代码，在controller中再写数据控制逻辑。
    {
        try
        {
            var res = _userService.AddUser(input);
            return Ok(res);
        }
        catch (System.Exception ex)
        {
            JsonResult result = new JsonResult(ex)
            {
                StatusCode = 201,
            };
            return result;
        }
    }
}
