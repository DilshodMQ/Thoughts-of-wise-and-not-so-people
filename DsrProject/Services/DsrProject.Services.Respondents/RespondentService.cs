using AutoMapper;
using AutoMapper.Internal;
using DsrProject.Common.Exceptions;
using DsrProject.Common.Validator;
using DsrProject.Context;
using DsrProject.Context.Entities;
using DsrProject.Services.Respondents.Models;
using DsrProject.Services.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;

namespace DsrProject.Services.Respondents
{
    public class RespondentService : IRespondentService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddCommentModel> addCommentModelValidator;
        

        public RespondentService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IModelValidator<AddCommentModel> addCommentModelValidator
            )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addCommentModelValidator = addCommentModelValidator;

        }
        public async Task<CommentModel> AddComment(AddCommentModel model)
        {
            addCommentModelValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var comment = mapper.Map<Comment>(model);
            await context.Comments.AddAsync(comment);
            context.SaveChanges();

            return mapper.Map<CommentModel>(comment);
        }

        public async Task SendEmail(SubscribeThoughtModel model, MailSettings mailSettings)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var thought = context.Thoughts.FirstOrDefault(t => t.Id.Equals(model.ThoughtId))
                ?? throw new ProcessException($"Thought with {model.ThoughtId} has not found");

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(model.RespondentEmail));
            email.Subject = thought.Title;
            var builder = new BodyBuilder();


            builder.HtmlBody = thought.Description;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task Subscribe(SubscribeThoughtModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var respondent = context.Respondents.FirstOrDefault(r => r.Email.Equals(model.RespondentEmail))
                ?? throw new ProcessException($"Respondent with {model.RespondentEmail} has not found");

            var thoughtRespondent=mapper.Map<ThoughtRespondent>(model);
            thoughtRespondent.RespondentId = respondent.Id;

            context.ThoughtRespondents.Add( thoughtRespondent );
            await context.SaveChangesAsync();
        }

        public async Task UnSubscribe(SubscribeThoughtModel model)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var respondent=context.Respondents.FirstOrDefault(r=>r.Email.Equals(model.RespondentEmail))
                ??throw new ProcessException($"Respondent with {model.RespondentEmail} has not found");
            var thoughtRespondent = await context.ThoughtRespondents.FirstOrDefaultAsync(x => (x.ThoughtId.Equals(model.ThoughtId))&&(x.RespondentId.Equals(respondent.Id)))
               ?? throw new ProcessException($"This respondent has not subscribed to this thought");
            context.ThoughtRespondents.Remove( thoughtRespondent );
            await context.SaveChangesAsync();
        }
    }
}
