using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Interface;
using LoginRegister2.DATA.Model;
using Microsoft.AspNetCore.Identity;
using Response;
using MessageClass.Message;

namespace LoginRegister2.DATA.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager;

        public UserServices(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Response<User>> ChangePassword(string tkn, UserPassword userpassword)
        {
            
            User user = await _userManager.FindByEmailAsync(tkn);
            if(userpassword.CurrentPassword!=userpassword.NewPassword)
            {
                if (userpassword.NewPassword == userpassword.ConfirmPassword)
                {
                    var r = await _userManager.ChangePasswordAsync(user, userpassword.CurrentPassword, userpassword.NewPassword);
                    if (!r.Succeeded)
                    {
                        Response<User>.Fail(Message.OldPasswordIncorrect);
                    }
                    await _userManager.UpdateAsync(user);
                    return Response<User>.Success(user);
                }
               return Response<User>.Fail(Message.PasswordIncorrect);
            }
            return Response<User>.Fail(Message.PasswordChangeError);
        }

        public async Task<Response<User>> EMailVertification(string tkn,NewPasswordModel passwordModel)
        {
            var user=await _userManager.FindByEmailAsync(tkn);
            
            if(user.PIN==passwordModel.PIN)
            {
               
                var password = await _userManager.ChangePasswordAsync(user, user.PasswordHash, 
                    passwordModel.NewPassword);
                if(!password.Succeeded)
                {
                    Response<User>.Fail(Message.OldPasswordIncorrect);
                }
                user.PIN=null;
                await _userManager.UpdateAsync(user);

                return Response<User>.Success(user);
            }
            return Response<User>.Fail(Message.ValidationError);
        }
    }
    }
