using Microsoft.AspNetCore.Identity;

namespace LoginRegister2.DATA.Model
{
    public class User :IdentityUser
    {
        public string? NameSurname{ get; set; }
        public string? PIN { get; set; }

        public  ICollection<Address> addresses { get; set; }

    }

    

}
