using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace webapi.barberdevs.Utils.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings>options)
        {
            emailSettings = options.Value;   
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                // objeto que representa o email
                var email = new MimeMessage();

                // definimos o remetente
                email.Sender = MailboxAddress.Parse(emailSettings.Email);

                // definimos o destinatario do email
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

                // define o assunto do email
                email.Subject = mailRequest.Subject;

                // cria o corpo do email
                var builder = new BodyBuilder();

                // define o corpo do email como html
                builder.HtmlBody = mailRequest.Body;

                // define o corpo do email no obj MimeMessage
                email.Body = builder.ToMessageBody();

                // cria um client SMT para envio de email
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(emailSettings.Host, emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);

                    smtp.Authenticate(emailSettings.Email, emailSettings.Password);

                    await smtp.SendAsync(email);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
