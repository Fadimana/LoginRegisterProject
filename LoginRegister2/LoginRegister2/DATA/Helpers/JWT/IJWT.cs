using LoginRegister2.DATA.Model;

namespace LoginRegister2.DATA.Helpers.JWT
{
    public interface IJWT
    {
        string CreateToken(User user);
    }
}
