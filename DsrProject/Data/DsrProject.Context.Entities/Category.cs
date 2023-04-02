using DsrProject.Context.Entities.Common;

namespace DsrProject.Context.Entities
{
    public class Category : BaseEntity
    {
        public string  Title { get; set; }
        public ICollection<ThoughtCategory> ThoughtCategories { get; set; }
    }
}
