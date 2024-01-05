using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using SHJ.Identity.Options;

namespace SHJ.Identity.Emailing;

public class EmailSender : IEmailSenders
{
    private IOptions<MailingSmtpOptions> _options;
    public EmailSender(IOptions<MailingSmtpOptions> options)
    {
        _options = options;
    }
    public  Task SendAsync(ComposeOptions compose)
    {
        using (var client = new SmtpClient())
        {
            if (string.IsNullOrEmpty(_options.Value.UserName) ||
               string.IsNullOrEmpty(_options.Value.Password))
                throw new ArgumentNullException("username and password is not null");

            var credentials = new NetworkCredential()
            {
                UserName = _options.Value.UserName,
                Password = _options.Value.Password,
            };

            client.Credentials = credentials;
            client.Host = _options.Value.Host;
            client.Port = _options.Value.Port;
            client.EnableSsl = _options.Value.EnableSsl;

            using var emailMessage = new MailMessage()
            {
                To = { new MailAddress(compose.ToEmail) },
                From = new MailAddress(_options.Value.UserName),
                Subject = compose.Subject,
                Body = compose.Message,
                IsBodyHtml = compose.IsMessageHtml,
            };

            client.Send(emailMessage);
        }

        return Task.CompletedTask;
    }

    public Task SendAsync(ComposeOptions compose, MailingSmtpOptions smtpOptions)
    {
        using (var client = new SmtpClient())
        {
            if (string.IsNullOrEmpty(smtpOptions.UserName) ||
               string.IsNullOrEmpty(smtpOptions.Password))
                throw new ArgumentNullException("username and password is not null");

            var credentials = new NetworkCredential()
            {
                UserName = smtpOptions.UserName,
                Password = smtpOptions.Password,
            };

            client.Credentials = credentials;
            client.Host = smtpOptions.Host;
            client.Port = smtpOptions.Port;
            client.EnableSsl = smtpOptions.EnableSsl;

            using var emailMessage = new MailMessage()
            {
                To = { new MailAddress(compose.ToEmail) },
                From = new MailAddress(smtpOptions.UserName),
                Subject = compose.Subject,
                Body = compose.Message,
                IsBodyHtml = compose.IsMessageHtml,
            };

            client.Send(emailMessage);
        }

        return Task.CompletedTask;
    }
}
