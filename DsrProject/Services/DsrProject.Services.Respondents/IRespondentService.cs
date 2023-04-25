using DsrProject.Services.Respondents.Models;
using DsrProject.Services.Settings;

namespace DsrProject.Services.Respondents
{
    public interface IRespondentService
    {
        Task<CommentModel> AddComment(AddCommentModel model);
        Task Subscribe(SubscribeThoughtModel model, MailSettings mailSettings);
        Task UnSubscribe(SubscribeThoughtModel model, MailSettings mailSettings);

    }
}
