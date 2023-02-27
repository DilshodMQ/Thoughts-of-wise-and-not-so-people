using DsrProject.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Entities
{
    public class Author : BaseEntity
    {
        public string  Name { get; set; }
        public AuthorDetail Detail { get; set; }

        public ICollection<Thought> Thoughts { get; set; }
    }
}
