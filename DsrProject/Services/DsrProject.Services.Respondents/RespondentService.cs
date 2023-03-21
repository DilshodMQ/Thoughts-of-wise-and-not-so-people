using AutoMapper;
using DsrProject.Common.Exceptions;
using DsrProject.Common.Validator;
using DsrProject.Context;
using DsrProject.Context.Entities;
using DsrProject.Services.Respondents.Models;
using Microsoft.EntityFrameworkCore;

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
