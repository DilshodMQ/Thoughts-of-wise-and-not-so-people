using DsrProject.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Entities
{
    public class Category :BaseEntity
    {
        public int CategoryId { get; set; }
        public string  Title { get; set; }

        public ICollection<ThoughtCategory> ThoughtCategories { get; set; }
    }
}
