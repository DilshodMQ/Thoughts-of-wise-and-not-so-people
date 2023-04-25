using DsrProject.Common.Exceptions;
using DsrProject.Context;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MimeKit;


namespace DsrProject.Services.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public ILogger<EmailSender> logger { get; }
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public EmailSender(ILogger<EmailSender> logger,
                           IDbContextFactory<MainDbContext> contextFactory)
        {
            this.logger = logger;
            this.contextFactory = contextFactory;
        }
        public async Task Send(EmailModel model)
        {      
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(model.SenderEmail);
            email.To.Add(MailboxAddress.Parse(model.RespondentEmail));
            email.Subject = model.Subject;
            var builder = new BodyBuilder();


            builder.HtmlBody = model.Message;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(model.Host, model.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(model.SenderEmail, model.SenderPassword);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);

            
        }
    }
}