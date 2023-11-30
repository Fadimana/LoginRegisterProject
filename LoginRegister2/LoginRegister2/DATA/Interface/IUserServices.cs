using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Model;
using Response;

namespace LoginRegister2.DATA.Interface
{
    public interface IUserServices
    {
        Task <Response<User>> ChangePassword(string tkn ,UserPassword userPassword);
        Task<Response<User>> EMailVertification(string tkn,NewPasswordModel passwordModel);
    }
}
