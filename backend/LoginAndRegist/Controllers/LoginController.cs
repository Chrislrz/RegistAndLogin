using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Dto;

namespace LoginAndRegist.Controllers;

[ApiController]
[Route("[controller]/[Action]")]

public class LoginController : Controller
{
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _userService.Login(loginDto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //如果您想使用 HTTP GET 方法来处理登录请求，您可以将 HttpPost 属性更改为 HttpGet。
        //然而，使用 GET 方法来处理登录请求并不是一个好的做法，
        //因为它会将敏感信息（如用户名和密码）以明文形式暴露在 URL 中，这可能会导致安全问题。
        //
        //[HttpGet]
        // public async Task<ActionResult> Login(string username, string password)
        // {
        //     try
        //     {
        //         var loginDto = new LoginDto { Username = username, Password = password };
        //         var user = await _userService.Login(loginDto);
        //         return Ok(user);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
        // 
        
        //就是说get方法并不安全，不如使用post进行信息比对来获取数据。
}
