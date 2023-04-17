using AutoMapper;
using DsrProject.Context.Entities;

namespace DsrProject.Services.UserAccount
{
    public class UserAccountModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
   
}
