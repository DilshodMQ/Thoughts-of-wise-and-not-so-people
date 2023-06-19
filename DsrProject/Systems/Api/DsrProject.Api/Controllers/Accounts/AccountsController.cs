using AutoMapper;
using DsrProject.Api.Controllers.Accounts.Models;
using DsrProject.API.Controllers.Models;
using DsrProject.Common.Exceptions;
using DsrProject.Common.Responses;
using DsrProject.Context.Entities;
using DsrProject.Services.Actions;
using DsrProject.Services.EmailSender;
using DsrProject.Services.Settings;
using DsrProject.Services.UserAccount;
using DsrProject.Services.UserAccount.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Text;

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
    [Route("api/v{version:apiVersion}/accounts")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<AccountsController> logger;
        private readonly IUserAccountService userAccountService;
        private readonly UserManager<User> userManager;
        private readonly IAction action;
        private readonly MailSettings mailSettings;
        public AccountsController(IMapper mapper,
            ILogger<AccountsController> logger,
            IUserAccountService userAccountService,
            IAction action,
            IOptions<MailSettings> mailSettings,
            UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.userAccountService = userAccountService;
            this.userManager = userManager;
            this.action = action;
            this.mailSettings = mailSettings.Value;
        }

        /// <summary>
        /// Add User
        /// </summary>

        [HttpPost("Registr")]
        public async Task<UserAccountResponse> Registr([FromBody] RegisterUserAccountRequest request)
        {
            var user = await userAccountService.Create(mapper.Map<RegisterUserAccountModel>(request));

            var response = mapper.Map<UserAccountResponse>(user);

            return response;
        }

        [HttpPost("ChangePassword")]
        [Authorize]
        public async Task<ChangePasswordResponse> ChangePassword([FromQuery] ChangePasswordRequest request)
        {
            var user = await userManager.GetUserAsync(User);
            var model = mapper.Map<ChangePasswordModel>(request);
            var changedPass = await userAccountService.ChangePassword(model, user);

            var response = mapper.Map<ChangePasswordResponse>(changedPass);
            return response;
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ProcessException($"User with email {request.Email} not found");
            }

            var resetPasswordToken = await  userManager.GeneratePasswordResetTokenAsync(user);
            var encodeResetPasswordToken = Encoding.UTF8.GetBytes(resetPasswordToken);
            var validResetPasswordToken = WebEncoders.Base64UrlEncode(encodeResetPasswordToken);

            var url = $"http://host.docker.internal:10002/ResetPassword?email={user.Email}&token={validResetPasswordToken}";
           // var url = Url.Action(nameof(ResetPassword), "Accounts", new { token=token.Result.ToString(), email = user.Email }, Request.Scheme);

            await action.SendEmail(new EmailModel
            {
                SenderEmail = mailSettings.Mail,
                SenderPassword = mailSettings.Password,
                Host = mailSettings.Host,
                Port = mailSettings.Port,
                RespondentEmail = request.Email,
                Subject = "Thoughts notification",
                Message = $"Forgot password link <a href='{url}'> Click here </a>"
            });;
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return Ok(new
            {
                model
            });
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            var user = await userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                throw new ProcessException($"User with email {resetPassword.Email} not found");
            }

            var resPassResult = await userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if(resPassResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            
        }
    }
}
