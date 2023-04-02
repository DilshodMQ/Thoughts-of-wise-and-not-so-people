using AutoMapper;
using DsrProject.Services.Thoughts;

namespace DsrProject.API.Controllers.Models
{
    public class ThoughtResponse
    {
        /// <summary>
        /// Thought Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// thought content
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// thought description
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Author Id
        /// </summary>
        public int AuthorId { get; set; }

    }

}
