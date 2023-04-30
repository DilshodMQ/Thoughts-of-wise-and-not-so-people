using AutoMapper;
using DsrProject.Services.Thoughts;

namespace DsrProject.API.Controllers.Models
{
    public class CategoryResponse
    {
        /// <summary>
        /// Comment Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Comment content
        /// </summary>
        public string Title { get; set; } = string.Empty;

        public string  Author { get; set; }

    }

}
