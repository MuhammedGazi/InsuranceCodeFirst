using MailKit.Net.Smtp;
using MimeKit;

namespace InsuranceCodeFirst.Business.Services.AIChatGptServices
{
    public class EmailSender
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Müşteri Hizmetleri", "emailin"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body ?? "İçerik yüklenemedi."
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("Emalin", "emailappşifresi");

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}