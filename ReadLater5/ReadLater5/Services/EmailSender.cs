using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ReadLater5.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSenderOptions Options { get; }

        public EmailSender(IOptions<EmailSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string fromMail = Options.From;
            string fromPassword = Options.Password;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(Options.From);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(Options.SmtpServer)
            {
                Port = Options.Port,
                Credentials = new NetworkCredential(Options.From, Options.Password),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
    }
}
