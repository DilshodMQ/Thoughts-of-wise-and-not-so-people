namespace DsrProject.Services.Authors
{

    public interface IAuthorService
    {
        Task<IEnumerable<AuthorModel>> GetAuthors();
    }
}