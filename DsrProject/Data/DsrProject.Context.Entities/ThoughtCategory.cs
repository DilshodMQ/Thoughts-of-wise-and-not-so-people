using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Entities
{
    public class ThoughtCategory
    {
        public int ThoughtId { get; set; }
        public Thought Thought { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
