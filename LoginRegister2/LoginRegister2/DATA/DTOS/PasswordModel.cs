using System.ComponentModel.DataAnnotations;

namespace LoginRegister2.DATA.DTOS
{
    public class PasswordModel
    {
        [Required]
        public string PIN { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
