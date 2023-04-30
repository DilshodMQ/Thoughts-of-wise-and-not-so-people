using AutoMapper;
using DsrProject.Api.Controllers.Respondents.Models;
using DsrProject.API.Controllers.Models;
using DsrProject.Common.Responses;
using DsrProject.Common.Security;
using DsrProject.Services.Respondents;
using DsrProject.Services.Respondents.Models;
using DsrProject.Services.Settings;
using DsrProject.Services.Thoughts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
    [Route("api/v{version:apiVersion}/respondents")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RespondentsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<RespondentsController> logger;
        private readonly IRespondentService respondentService;
        private readonly MailSettings mailSettings;
        private readonly IThoughtService thoughtService;
        public RespondentsController(
            IMapper mapper,
            ILogger<RespondentsController> logger,
            IRespondentService respondentService,
            IThoughtService thoughtService,
            IOptions<MailSettings> mailSettings)

        {
            this.mapper = mapper;
            this.logger = logger;
            this.respondentService = respondentService;
            this.mailSettings = mailSettings.Value;
            this.thoughtService = thoughtService;
        }

        /// <summary>
        /// Get Thoughts
        /// </summary>
        /// <param name="offset">Offset to the first element</param>
        /// <param name="limit">Count elements on the page</param>
        /// <response code="200">List of ThoughtResponses</response>
        [ProducesResponseType(typeof(IEnumerable<ThoughtResponse>), 200)]
        [HttpGet("")]

        public async Task<IEnumerable<ThoughtResponse>> GetRespondentThoughts([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var thoughts = await thoughtService.GetThoughts(offset, limit);
            var response = mapper.Map<IEnumerable<ThoughtResponse>>(thoughts);

            return response;
        }

        /// <summary>
        /// Add comment
        /// </summary>

        [HttpPost("AddComment")]
        public async Task<CommentResponse> AddComment([FromBody] AddCommentRequest request)
        {
            var model = mapper.Map<AddCommentModel>(request);
            var comment = await respondentService.AddComment(model);
            var response = mapper.Map<CommentResponse>(comment);

            return response;
        }

        /// <summary>
        /// Subscribe to Thought
        /// </summary>

        [HttpPost("Subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] SubscribeThoughtRequest request)
        {
            var model = mapper.Map<SubscribeThoughtModel>(request);
            await  respondentService.Subscribe(model, mailSettings);

            return Ok();
        }

        /// <summary>
        /// UnSubscribe from Thought
        /// </summary>

        [HttpPost("UnSubscribe")]
        public async Task<IActionResult> UnSubscribe([FromBody] SubscribeThoughtRequest request)
        {
            var model = mapper.Map<SubscribeThoughtModel>(request);
            await respondentService.UnSubscribe(model, mailSettings);
            return Ok();
        }
    }
}
