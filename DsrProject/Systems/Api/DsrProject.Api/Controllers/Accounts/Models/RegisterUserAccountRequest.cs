using AutoMapper;
using DsrProject.Services.UserAccount;
using FluentValidation;

namespace DsrProject.API.Controllers.Models
{
    public class RegisterUserAccountRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

