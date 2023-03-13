using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsrProject.Services.Respondents.Models
{
    public class AddCommentModel
    {
        public string Content { get; set; }

        public int RespondentId { get; set; }

        public int ThoughtId { get; set; }
    }
}
