using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace test.Ulity
{
    public  class Ulity
    {
        public bool IsSend(string text, string title,string Email)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("rhemyroobbbb@gmail.com", "nzftcjytisghhcbl");
                client.UseDefaultCredentials = false;
                MailAddress from = new MailAddress("rhemyroobbbb@gmail.com");
                MailAddress to = new MailAddress(Email);
                MailMessage message = new MailMessage(from, to);
                message.Body = text;
                message.BodyEncoding = Encoding.UTF8;
                message.Subject = title;
                message.SubjectEncoding = Encoding.UTF8;
                client.Send(message);
                message.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
