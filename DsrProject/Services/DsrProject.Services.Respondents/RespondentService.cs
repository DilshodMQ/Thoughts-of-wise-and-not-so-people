using AutoMapper;
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
    }
}
