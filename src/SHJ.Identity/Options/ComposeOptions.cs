using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJ.Identity.Options;

public class ComposeOptions
{


    public ComposeOptions(string toEmail, string subject, string message, bool isMessageHtml = false)
    {
        ToEmail = toEmail;
        Subject = subject;
        Message = message;
        IsMessageHtml = isMessageHtml;
    }
    public string ToEmail { get; private set; } = string.Empty;
    public string Subject { get; private set; } = string.Empty;
    public string Message { get; private set; } = string.Empty;
    public bool IsMessageHtml { get; private set; } = false;

}
