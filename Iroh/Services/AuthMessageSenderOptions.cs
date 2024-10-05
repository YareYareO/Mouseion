using SendGrid;
using SendGrid.Helpers.Mail;

namespace Iroh.Services
{
    public class AuthMessageSenderOptions
    {
        public string? SendGridKey { get; set; }
    }
}