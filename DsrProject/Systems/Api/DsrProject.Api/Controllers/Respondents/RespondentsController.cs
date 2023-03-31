using AutoMapper;
using DsrProject.Api.Controllers.Respondents.Models;
using DsrProject.Common.Responses;
using DsrProject.Services.Respondents;
using DsrProject.Services.Respondents.Models;
using DsrProject.Services.Settings;
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
        public RespondentsController(IMapper mapper, ILogger<RespondentsController> logger, IRespondentService respondentService, IOptions<MailSettings> mailSettings)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.respondentService = respondentService;
            this.mailSettings = mailSettings.Value;
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
            respondentService.Subscribe(model);
            await respondentService.SendEmail(model, mailSettings);
            return Ok();
        }

        /// <summary>
        /// UnSubscribe from Thought
        /// </summary>

        [HttpPost("UnSubscribe")]
        public async Task<IActionResult> UnSubscribe([FromBody] SubscribeThoughtRequest request)
        {
            var model = mapper.Map<SubscribeThoughtModel>(request);
            respondentService.UnSubscribe(model);
            return Ok();
        }
    }
}
