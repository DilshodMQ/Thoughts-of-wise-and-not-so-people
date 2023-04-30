using DsrProject.Web;
using System.Threading.Tasks;

namespace DsrProject.Web
{
    public interface IThoughtService
    {
        Task<IEnumerable<ThoughtListItem>> GetThoughts(int offset = 0, int limit = 10);
        Task<IEnumerable<ThoughtListItem>> GetRespondentThoughts(int offset = 0, int limit = 10);
        Task<ThoughtListItem> GetThought(int thoughtId);
        Task AddThought(ThoughtModel model);
        Task EditThought(int thoughtId, ThoughtModel model);
        Task DeleteThought(int thoughtId);

        Task<bool> Subscribe(int thoughtId, SubscribeModel model);
        Task<bool> UnSubscribe(int thoughtId, SubscribeModel model);
        Task<bool> AddComment(int thoughtId, AddCommentModel model);
        Task<IEnumerable<AuthorModel>> GetAuthorList();
        Task<IEnumerable<CategoryModel>> GetCategoryList();
    }
}
