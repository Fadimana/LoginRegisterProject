using System.Net.Mail;
using System.Net;

namespace LoginRegister2.DATA.Helpers.EmailSender
{
    public class EMailServices : IEmailServices
    {
        public void EmailSend(string email, string body)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("denememaili541@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Doğrulama kodu";
            mailMessage.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("denememaili541@gmail.com", "aaln krry tlgu nzcu");
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;


            smtp.Send(mailMessage);
        }
    }
}
