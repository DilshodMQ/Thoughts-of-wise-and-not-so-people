namespace DsrProject.Services.Thoughts
{
    public interface IThoughtService
    {
        Task<IEnumerable<ThoughtModel>> GetThoughts(int offset = 0, int limit = 10);
        Task<ThoughtModel> GetThought(int thoughtId);
        Task<ThoughtModel> AddThought(AddThoughtModel model);
        Task UpdateThought(int id, UpdateThoughtModel model);
        Task DeleteThought(int thoughtId);
    }
}
