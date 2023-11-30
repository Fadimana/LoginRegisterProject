using System.ComponentModel.DataAnnotations;

namespace LoginRegister2.DATA.DTOS
{
    public class RegisterModel
    {
        
        public string namesurname{ get; set; }
     
        public string email { get; set; }
        
        public string password { get; set; }
        
        public string confirmpassword { get; set; }

     
        public string username { get; set; }    


    }
}
