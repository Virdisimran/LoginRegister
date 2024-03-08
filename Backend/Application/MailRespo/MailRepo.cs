using Domain.DTOs;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Application.MailRespo
{
    public class MailRepo : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailRepo(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            if (_mailSettings == null)
            {
                throw new InvalidOperationException("Mail settings are not properly initialized.");
            }

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendUsernamePassword(string userEmail, string username, string password)
        {

            var mailRequest = new MailRequest
            {
                ToEmail = userEmail,
                Subject = "Username and Password",
                Body = $"Dear User, <br><br>Username: {username} <br>Password: {password}"
            };

            try
            {
                await SendEmailAsync(mailRequest);
                Console.WriteLine("Password reset email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending password reset email: {ex.Message}");
            }
        }

    }
}
