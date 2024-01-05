using SHJ.Identity.Options;

namespace SHJ.Identity.Emailing;

public interface IEmailSender
{
    public Task SendAsync(ComposeOptions compose);
    public Task SendAsync(ComposeOptions compose, MailingSmtpOptions smtpOptions);
    
}
