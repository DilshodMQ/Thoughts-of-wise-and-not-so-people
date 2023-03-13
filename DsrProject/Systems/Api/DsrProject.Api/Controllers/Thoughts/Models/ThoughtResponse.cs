using AutoMapper;
using DsrProject.Services.Thoughts;

namespace DsrProject.API.Controllers.Models
{
    public class ThoughtResponse
    {
        /// <summary>
        /// Comment Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Comment content
        /// </summary>
        public string Content { get; set; } = string.Empty;
        public int RespondentId { get; set; }
        public string Respondent { get; set; } = string.Empty;
        public int ThoughtId { get; set; }
        public string Thought{ get; set; } = string.Empty;
    }

}
