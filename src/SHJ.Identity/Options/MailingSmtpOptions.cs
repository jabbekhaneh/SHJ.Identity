namespace SHJ.Identity.Options;

public class MailingSmtpOptions
{

    public MailingSmtpOptions(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }
    public string Host { get; set; } = "smtp.gmail.com";
    public int Port { get; set; } = 587;
    public string UserName { get; private set; } = "";
    public string Password { get; private set; } = "";
    public string Domain { get; set; } = "";
    public bool EnableSsl { get; set; } = false;
    public bool UseDefaultCredentials { get; set; } = true;
    public string DefaultFromAddress { get; set; } = "example@mail.com";
    public string DefaultFromDisplayName { get; set; } = "SHJ identity application";
}