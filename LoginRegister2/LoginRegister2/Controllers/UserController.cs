using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Interface;
using LoginRegister2.DATA.Model;
using MessageClass.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Response;
using System.Data;
using System.Security.Claims;

namespace LoginRegister2.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(UserPassword userPassword)
        {
            //var userId = User.Claims.FirstOrDefault(x => x.Type == ("Id")).Value;
            var userId = User.FindFirst(ClaimTypes.Email)?.Value;
            Response<User> result = await _userServices.ChangePassword(userId, userPassword);
            if(result.IsSuccess) {
                return Ok(result);
            }
            return BadRequest(Message.PasswordChangeFailed);  
            
        }
        [HttpPost("EMailVertification")]
        public async Task<IActionResult> EMailVertification(NewPasswordModel passwordModel)
        {
            var userId = User.FindFirst(ClaimTypes.Email)?.Value;
            Response<User> result = await _userServices.EMailVertification(userId, passwordModel);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors);

        }

    }
}
