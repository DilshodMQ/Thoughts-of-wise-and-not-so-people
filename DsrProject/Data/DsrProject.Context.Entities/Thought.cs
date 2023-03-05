using DsrProject.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Entities
{
    public class Thought :BaseEntity
    {
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int ThoughtId { get; set; }
        public string Title { get; set; }

        public string  Description { get; set; }

        public ICollection<ThoughtCategory> ThoughtCategories { get; set; }

        public ICollection<ThoughtRespondent> ThoughtRespondents { get; set; }

    }
}
