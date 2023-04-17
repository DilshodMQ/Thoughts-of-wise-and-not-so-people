using AutoMapper;
using DsrProject.Api.Controllers.Accounts.Models;
using DsrProject.API.Controllers.Models;
using DsrProject.Services.UserAccount;
using DsrProject.Services.UserAccount.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DsrProject.API.Controllers
{
    [Route("api/v{version:apiVersion}/accounts")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<AccountsController> logger;
        private readonly IUserAccountService userAccountService;

        public AccountsController(IMapper mapper, ILogger<AccountsController> logger, IUserAccountService userAccountService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.userAccountService = userAccountService;
        }

        [HttpPost("")]
        public async Task<UserAccountResponse> Register([FromQuery] RegisterUserAccountRequest request)
        {
            var user = await userAccountService.Create(mapper.Map<RegisterUserAccountModel>(request));

            var response = mapper.Map<UserAccountResponse>(user);

            return response;
        }

        [HttpPost("ChangePassword")]
        public async Task<ChangePasswordResponse> ChangePassword([FromQuery]ChangePasswordRequest request)
        {
            var model = mapper.Map<ChangePasswordModel>(request);
            var changedPass = await userAccountService.ChangePassword(model);

            var response=mapper.Map<ChangePasswordResponse>(changedPass);
            return response;
        }
    }
}
