﻿using AutoMapper;
using DsrProject.API.Controllers.Models;
using DsrProject.Common.Responses;
using DsrProject.Common.Security;
using DsrProject.Services.Thoughts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DsrProject.API.Controllers
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
    [Route("api/v{version:apiVersion}/thoughts")]
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    public class ThoughtsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<ThoughtsController> logger;
        private readonly IThoughtService thoughtService;

        public ThoughtsController(IMapper mapper, ILogger<ThoughtsController> logger, IThoughtService thoughtService)
        {
            this.mapper = mapper;
            this.logger = logger;
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
        [Authorize(Policy = AppScopes.ThoughtsRead)]
        public async Task<IEnumerable<ThoughtResponse>> GetThoughts([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var thoughts = await thoughtService.GetThoughts(offset, limit);
            var response = mapper.Map<IEnumerable<ThoughtResponse>>(thoughts);

            return response;
        }

        /// <summary>
        /// Get thought by Id
        /// </summary>
        /// <response code="200">ThoughtResponse></response>
        [ProducesResponseType(typeof(ThoughtResponse), 200)]
        [HttpGet("{id}")]
        [Authorize(Policy = AppScopes.ThoughtsRead)]
        public async Task<ThoughtResponse> GetThoughtById([FromRoute] int id)
        {
            var thought = await thoughtService.GetThought(id);
            var response = mapper.Map<ThoughtResponse>(thought);

            return response;
        }

        [HttpPost("")]
        [Authorize(Policy = AppScopes.ThoughtsWrite)]
        public async Task<ThoughtResponse> AddThought([FromBody] AddThoughtRequest request)
        {
            var model = mapper.Map<AddThoughtModel>(request);
            var thought = await thoughtService.AddThought(model);
            var response = mapper.Map<ThoughtResponse>(thought);

            return response;
        }

        [HttpPut("{id}")]
        [Authorize(Policy = AppScopes.ThoughtsWrite)]
        public async Task<IActionResult> UpdateThought([FromRoute] int id, [FromBody] UpdateThoughtRequest request)
        {
            var model = mapper.Map<UpdateThoughtModel>(request);
            await thoughtService.UpdateThought(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = AppScopes.ThoughtsWrite)]
        public async Task<IActionResult> DeleteThought([FromRoute] int id)
        {
            await thoughtService.DeleteThought(id);

            return Ok();
        }
    }
}
