namespace Jshop.Backend.Services
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using System;
    using System.Threading.Tasks;

    public class EmailSender : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }
    }
}
