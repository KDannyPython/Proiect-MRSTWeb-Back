using MailKit.Net.Smtp;
using MimeKit;

namespace HealthMonitor.BusinessLayer.Structure;

public class EmailActions
{
    private readonly IConfiguration _configuration;

    public EmailActions()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json");

        _configuration = builder.Build();
    }

    public bool SendEmailAction(string to, string subject, string body)
    {
        try
        {
            var emailAddress = _configuration["EmailSettings:Email"];

            var password = _configuration["EmailSettings:Password"];

            var host = _configuration["EmailSettings:Host"];

            var port = int.Parse(_configuration["EmailSettings:Port"]);

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(emailAddress));

            email.To.Add(MailboxAddress.Parse(to));

            email.Subject = subject;

            email.Body = new TextPart("html")
            {
                Text = body
            };

            using var smtp = new SmtpClient();

            smtp.Connect(host, port, MailKit.Security.SecureSocketOptions.StartTls);

            smtp.Authenticate(emailAddress, password);

            smtp.Send(email);

            smtp.Disconnect(true);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
