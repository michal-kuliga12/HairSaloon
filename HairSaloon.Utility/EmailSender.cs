using Microsoft.AspNetCore.Identity.UI.Services;

namespace HairSaloon.Utility;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Logic to send email
        throw new NotImplementedException();
    }
}
