using System;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Saloon.Common
{
    public class SendEmail
    {
        public async Task<bool> Send(string subject, string body, string to, string from, string password, Attachment attachment = null)
        {
            try
            {
                //string from = "notifications@tpmechanisms.com";
                //string password = "tpm@1122-Notification$";

                if (subject == null || subject == "" || to == null || to == "" || from == null || from == "" || password == null || password == "")
                    throw new ArgumentNullException("Invalid Argument for sending email");


                string[] tempfrom = from.Split('@');

                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(from, "TPM", Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Body = body;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                if (attachment != null)
                    mail.Attachments.Add(attachment);


                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(from, password);
                client.Port = 587;
                client.Host = "smtp.zoho.com";
                client.EnableSsl = true;
                await client.SendMailAsync(mail);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
