using Common.Models.EmailSender;
using MailKit.Net.Smtp;
using MimeKit;

namespace Business.EmailSender;


public interface IEmailSendingHandler
{
    Task SendEmailAsync(EmailInfo email, CancellationToken cancellationToken);
}


public class EmailSendingHandler : IEmailSendingHandler
{
    private readonly SmtpSettings _settings;
    public EmailSendingHandler(SmtpSettings settings)
    {
        _settings = settings;
    }

    public async Task SendEmailAsync(EmailInfo email, CancellationToken cancellationToken)
    {
        var host = _settings.Host;
        var port = _settings.Port;

        var enableSsl = _settings.EnableSsl;
        var userName = _settings.UserName;
        var password = _settings.Password;
        var mediaType = _settings.MediaType;

        var message = new MimeMessage();

        message.Subject = email.Subject;
        message.Body = new TextPart(mediaType)
        {
            Text = email.Emailbody
        };

        message.From.Add(new MailboxAddress(email.Sender.DisplayName, email.Sender.Email));
        message.To.AddRange(email.Recipients.Select(p => new MailboxAddress(p.DisplayName, p.Email)));

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(host, port, enableSsl, cancellationToken);
            await client.AuthenticateAsync(userName, password, cancellationToken);
            await client.SendAsync(message, cancellationToken);
            await client.DisconnectAsync(true, cancellationToken);
        }
    }
}
