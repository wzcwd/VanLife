using SendGrid;
using SendGrid.Helpers.Mail;

namespace VanLife.Utility;

public class SendGridEmailSender
{
    private readonly string _apiKey;
    private readonly string _senderEmail;
    private readonly string _senderName;

    public SendGridEmailSender(IConfiguration config)
    {
        _apiKey = config["SendGrid:ApiKey"];
        _senderEmail = config["SendGrid:SenderEmail"];
        _senderName = config["SendGrid:SenderName"];
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress(_senderEmail, _senderName);
        var to = new EmailAddress(toEmail);
        var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
        var response = await client.SendEmailAsync(msg);
    }
    
}