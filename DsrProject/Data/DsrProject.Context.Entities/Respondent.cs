using DsrProject.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Context.Entities
{
    public class Respondent : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Thought> Thoughts { get; set; }
    }
}
