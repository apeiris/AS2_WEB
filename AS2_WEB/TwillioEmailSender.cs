using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;

namespace AS2_WEB
{
    public class TwillioEmailSender
    {
        private readonly string _sendGridApiKey;

        public TwillioEmailSender(IConfiguration config)
        {
            _sendGridApiKey = config.GetValue<string>("SendGridAPIKey");
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var from = new EmailAddress("sender@example.com", "Sender Name");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
