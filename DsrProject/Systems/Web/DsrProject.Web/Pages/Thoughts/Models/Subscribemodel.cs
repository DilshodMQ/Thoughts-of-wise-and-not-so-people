using FluentValidation;
namespace DsrProject.Web
{
    public class SubscribeModel
    {
        public int thoughtId { get; set; }
        public string respondentEmail { get; set; } = string.Empty;
    }
}