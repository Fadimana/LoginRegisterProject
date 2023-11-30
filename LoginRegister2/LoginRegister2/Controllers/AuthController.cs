
using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Helpers.Validation;
using LoginRegister2.DATA.Interface;
using LoginRegister2.DATA.Model;
using MessageClass.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Response;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LoginRegister2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        public AuthController(IAuthServices authServices, UserManager<User> userManager)
        {
            _authServices = authServices;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterModel registermodel)
        {

            if (ModelState.IsValid)
            {
                var result = await _authServices.Register(registermodel);
                if (!result.IsSuccess)
                    return BadRequest(result);
            }

            return BadRequest();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            Response<string> result = await _authServices.Login(loginModel);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
                return NotFound(Message.UserNotFound);
        }
        [HttpPost("Forget Password")]
        public async Task<IActionResult> ForgetPassword(EmailModel emailModel)
        {
            var result = await _authServices.ForgetPassword(emailModel);
            if (result.IsSuccess)
            {
                return Ok(result);

            }
            return BadRequest(result.Errors);

        }
    }
}
