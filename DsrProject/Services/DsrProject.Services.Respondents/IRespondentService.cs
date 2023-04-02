using DsrProject.Services.Respondents.Models;
using DsrProject.Services.Settings;

namespace DsrProject.Services.Respondents
{
    public interface IRespondentService
    {
        Task<CommentModel> AddComment(AddCommentModel model);
        Task Subscribe(SubscribeThoughtModel model);
        Task UnSubscribe(SubscribeThoughtModel model);
        Task SendEmail(SubscribeThoughtModel model, MailSettings mailSettings);
    }
}
