
using LoginRegister2.DATA.DTOS;
using LoginRegister2.DATA.Helpers.EmailSender;
using LoginRegister2.DATA.Helpers.JWT;

using LoginRegister2.DATA.Interface;
using LoginRegister2.DATA.Model;
using MessageClass.Message;
using Microsoft.AspNetCore.Identity;
using Response;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace LoginRegister2.DATA.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<User> _userManager;
        private readonly IJWT _jWT;
        private readonly IEmailServices _emailServices;

       // FluentValidation.Results.ValidationResult resultValidation=
        public AuthServices(UserManager<User> userManager, SignInManager<User> signInManager, IJWT jWT, IEmailServices emailServices)
        {
            _userManager = userManager;
            _jWT = jWT;
            _emailServices = emailServices;
        }

        public async Task<Response<EmailModel>> ForgetPassword(EmailModel model)
        {
            Random random = new Random();
            string rndm = random.Next(1000, 9999).ToString();
            User user = await _userManager.FindByEmailAsync(model.email);
           
            if (user != null)
            {
              if(user.Email==model.email)
                {
                    user.PIN = rndm;
                    await _userManager.UpdateAsync(user);
                    var jwt = _jWT.CreateToken(user);
                    var sonuc = jwt + " " + rndm;
                    _emailServices.EmailSend(model.email, sonuc);               
                    return Response<EmailModel>.Success(model);
                }
                else return Response<EmailModel>.Fail(Message.EmailIncorrect);
            }
            else
            {
                return Response<EmailModel>.Fail(Message.UserNotFound);
            }
        }
        public async Task<Response<string>> Login(LoginModel loginModel)
        {

            JWTTokenModel jWTTokenModel = new JWTTokenModel();
            var user = await _userManager.FindByEmailAsync(loginModel.email);
            var a = await _userManager.CheckPasswordAsync(user, loginModel.password);


            if (user != null && a == true)
            {
                jWTTokenModel.token = _jWT.CreateToken(user);
                var token=  jWTTokenModel.token;
                return Response<string>.Success(token);
            }

            return Response<string>.Fail(Message.LoginFailed);
        }






        public async Task<Response<string>> Register(RegisterModel registerModel)
        {
           

            var email = await _userManager.FindByEmailAsync(registerModel.email);
            if(email != null)
            {
                return Response<string>.Fail(Message.UserAlreadyExists);
            }
            User user = new User
            {
                Email = registerModel.email,
                UserName = registerModel.username,
                NameSurname = registerModel.namesurname
            };

            IdentityResult result = await _userManager.CreateAsync(user,registerModel.password);     
            

            if(!result.Succeeded)
                return Response<string>.Fail(result.Errors.Select(e => e.Description));

            return Response<string>.Success("Kayıt başarılı!");

        }
    }
}






