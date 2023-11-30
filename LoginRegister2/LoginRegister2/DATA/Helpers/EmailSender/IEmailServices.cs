namespace LoginRegister2.DATA.Helpers.EmailSender
{
    public interface IEmailServices
    {
        public void EmailSend(string email,string body);  

    }
}
