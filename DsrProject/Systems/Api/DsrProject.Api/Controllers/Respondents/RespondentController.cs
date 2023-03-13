using AutoMapper;
using DsrProject.Api.Controllers.Respondents.Models;
using DsrProject.Common.Responses;
using DsrProject.Services.Respondents;
using DsrProject.Services.Respondents.Models;
using Microsoft.AspNetCore.Mvc;

namespace DsrProject.Api.Controllers.Respondents
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
    [Route("api/v{version:apiVersion}/respondent")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RespondentController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<RespondentController> logger;
        private readonly IRespondentService respondentService;

        public RespondentController(IMapper mapper, ILogger<RespondentController> logger, IRespondentService respondentService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.respondentService = respondentService;
        }

        [HttpPost("")]
        public async Task<CommentResponse> AddComment([FromBody] AddCommentRequest request)
        {
            var model = mapper.Map<AddCommentModel>(request);
            var comment = await respondentService.AddComment(model);
            var response = mapper.Map<CommentResponse>(comment);

            return response;
        }
    }
}
