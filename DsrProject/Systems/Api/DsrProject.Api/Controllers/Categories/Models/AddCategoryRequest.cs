﻿namespace DsrProject.API.Controllers.Models
{
    public class AddCategoryRequest
    {
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
    }
}

