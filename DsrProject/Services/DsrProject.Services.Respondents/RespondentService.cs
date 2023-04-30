using AutoMapper;
using DsrProject.Common.Exceptions;
using DsrProject.Common.Validator;
using DsrProject.Context;
using DsrProject.Context.Entities;
using DsrProject.Services.Actions;
using DsrProject.Services.EmailSender;
using DsrProject.Services.Respondents.Models;
using DsrProject.Services.Settings;
using Microsoft.EntityFrameworkCore;

namespace DsrProject.Services.Respondents
{
    public class RespondentService : IRespondentService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddCommentModel> addCommentModelValidator;
        private readonly IAction action;
        

        public RespondentService(
            IDbContextFactory<MainDbContext> contextFactory,
            IMapper mapper,
            IAction action,
            IModelValidator<AddCommentModel> addCommentModelValidator
            )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addCommentModelValidator = addCommentModelValidator;
            this.action=action;

        }
        public async Task<CommentModel> AddComment(AddCommentModel model)
        {
            addCommentModelValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var user = context.Users.FirstOrDefault(r => r.Email.Equals(model.RespondentEmail))
                 ?? throw new ProcessException($"Respondent with {model.RespondentEmail} has not found");

            var comment = mapper.Map<Comment>(model);
            comment.UserId= user.Id;
            await context.Comments.AddAsync(comment);
            context.SaveChanges();

            return mapper.Map<CommentModel>(comment);
        }


        public async Task Subscribe(SubscribeThoughtModel model, MailSettings mailSettings)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var user = context.Users.FirstOrDefault(r => r.Email.Equals(model.RespondentEmail))
                ?? throw new ProcessException($"Respondent with {model.RespondentEmail} has not found");
            var thought = context.Thoughts.FirstOrDefault(t => t.Id.Equals(model.ThoughtId))
                ?? throw new ProcessException($"Thought with {model.ThoughtId} has not found");

            var thoughtUser = new ThoughtUser();
            thoughtUser.ThoughtId = model.ThoughtId;
            thoughtUser.UserId = user.Id;

            context.ThoughtUsers.Add(thoughtUser);
            await context.SaveChangesAsync();

            await action.SendEmail(new EmailModel
            {
                SenderEmail=mailSettings.Mail,
                SenderPassword=mailSettings.Password,
                Host=mailSettings.Host,
                Port=mailSettings.Port,
                ThoughtId=model.ThoughtId,
                RespondentEmail = model.RespondentEmail,
                Subject = "Thoughts notification",
                Message = $"You have subscribed to thought {thought.Title} {thought.Description}"
            });
        }

        public async Task UnSubscribe(SubscribeThoughtModel model, MailSettings mailSettings)
        {
            using var context = await contextFactory.CreateDbContextAsync();
            var user = context.Users.FirstOrDefault(r => r.Email.Equals(model.RespondentEmail))
                ?? throw new ProcessException($"Respondent with {model.RespondentEmail} has not found");

            var thoughtUser = await context.ThoughtUsers.FirstOrDefaultAsync( x => (x.ThoughtId.Equals(model.ThoughtId)) && (x.UserId.Equals(user.Id)))
               ?? throw new ProcessException($"This respondent has not subscribed to this thought");
            context.ThoughtUsers.Remove(thoughtUser);
            var thought = context.Thoughts.FirstOrDefault(t => t.Id.Equals(model.ThoughtId))
                ?? throw new ProcessException($"Thought with {model.ThoughtId} has not found");

            context.ThoughtUsers.Remove(thoughtUser);
            await context.SaveChangesAsync();

            await action.SendEmail(new EmailModel
            {
                SenderEmail = mailSettings.Mail,
                SenderPassword = mailSettings.Password,
                Host = mailSettings.Host,
                Port = mailSettings.Port,
                ThoughtId = model.ThoughtId,
                RespondentEmail = model.RespondentEmail,
                Subject = "Thoughts notification",
                Message = $"You have unsubscribed from thought {thought.Title}"
            });
        }
    }
}
