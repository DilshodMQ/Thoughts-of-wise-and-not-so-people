using DsrProject.Services.Respondents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Services.Respondents
{
    public interface IRespondentService
    {
        Task<CommentModel> AddComment(AddCommentModel model);
    }
}
