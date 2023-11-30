using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Helpers.JWT;
using LoginRegister2.DATA.Model;
using Microsoft.AspNetCore.Identity;
using Response;
namespace LoginRegister2.DATA.Interface
{
    public interface IAuthServices
    {
        Task<Response<string>> Register(RegisterModel registerModel);
        Task<Response<string>> Login(LoginModel loginModel);
        
        Task<Response<EmailModel>> ForgetPassword(EmailModel model);
    }
}
