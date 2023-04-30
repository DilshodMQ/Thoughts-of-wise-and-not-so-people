using AutoMapper;
using DsrProject.Common.Exceptions;
using DsrProject.Common.Validator;
using DsrProject.Context.Entities;
using DsrProject.Services.Actions;
using DsrProject.Services.EmailSender;
using DsrProject.Services.Settings;
using DsrProject.Services.UserAccount;
using DsrProject.Services.UserAccount.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;

namespace DsrProject.Services.UserAccount
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IMapper mapper;
        private readonly IAction action;
        private readonly UserManager<User> userManager;
        private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator;
        private readonly IModelValidator<ChangePasswordModel> changePasswordModelValidator;
        public UserAccountService(
            IMapper mapper,
            IAction action,
            UserManager<User> userManager,
            IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator,
            IModelValidator<ChangePasswordModel> changePasswordModelValidator)
        {
            this.mapper = mapper;
            this.action = action;
            this.userManager = userManager;
            this.registerUserAccountModelValidator = registerUserAccountModelValidator;
            this.changePasswordModelValidator= changePasswordModelValidator;
        }

        public async Task<ChangePasswordModel> ChangePassword(ChangePasswordModel model, User user)
        {
            changePasswordModelValidator.Check(model);

            if (user == null)
            {
                throw new ProcessException($"User account with email {model.Email} not found");
            }
            if (user.Email != model.Email)
            {
                throw new ProcessException("Email is wrong");
            }
            var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
            {
                throw new ProcessException($"oldPassword is wrong");
            }
            return model;
        }

       

        public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
        {
            registerUserAccountModelValidator.Check(model);

            // Find user by email
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
                throw new ProcessException($"User account with email {model.Email} already exist.");

            // Create user account
            user = new User()
            {
                Status = UserStatus.Active,
                FullName = model.Name,
                UserName = model.Email, 
                Email = model.Email,
                EmailConfirmed = true, 
                PhoneNumber = null,
                PhoneNumberConfirmed = false
               
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new ProcessException($"Creating user account is wrong. {String.Join(", ", result.Errors.Select(s => s.Description))}");
            return mapper.Map<UserAccountModel>(user);
        }

    }
}
