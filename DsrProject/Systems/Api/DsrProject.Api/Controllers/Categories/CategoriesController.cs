using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Common.Responses;
using DsrProject.Services.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DsrProject.Api.Controllers.Categories
{
    /// <summary>
    /// Thoughts controller
    /// </summary>
    /// <response code="400">Bad Request</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="403">Forbidden</response>
    /// <response code="404">Not Found</response>
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/categories")]
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<CategoriesController> logger;
        private readonly ICategoryService categoryService;

        public CategoriesController(IMapper mapper, ILogger<CategoriesController> logger, ICategoryService categoryService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Get Categories
        /// </summary>
        /// <param name="offset">Offset to the first element</param>
        /// <param name="limit">Count elements on the page</param>
        /// <response code="200">List of ThoughtResponses</response>
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), 200)]
        [HttpGet("")]
        public async Task<IEnumerable<CategoryResponse>> GetCategories([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var categories = await categoryService.GetCategories(offset, limit);
            var response = mapper.Map<IEnumerable<CategoryResponse>>(categories);

            return response;
        }

        /// <summary>
        /// Get category by Id
        /// </summary>
        /// <response code="200">ThoughtResponse></response>
        [ProducesResponseType(typeof(CategoryResponse), 200)]
        [HttpGet("{id}")]
        public async Task<CategoryResponse> GetCategoryById([FromRoute] int id)
        {
            var category = await categoryService.GetCategory(id);
            var response = mapper.Map<CategoryResponse>(category);

            return response;
        }

        [HttpPost("")]
        public async Task<CategoryResponse> AddCategory([FromBody] AddCategoryRequest request)
        {
            var model = mapper.Map<AddCategoryModel>(request);
            var category = await categoryService.AddCategory(model);
            var response = mapper.Map<CategoryResponse>(category);

            return response;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequest request)
        {
            var model = mapper.Map<UpdateCategoryModel>(request);
            await categoryService.UpdateCategory(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await categoryService.DeleteCategory(id);

            return Ok();
        }
    }
}
