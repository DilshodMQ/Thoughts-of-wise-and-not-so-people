using System.ComponentModel.DataAnnotations.Schema;

namespace DsrProject.Context.Entities.Common
{
    public abstract class BaseEntity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid Uid { get; set; } = Guid.NewGuid();
    }
}
