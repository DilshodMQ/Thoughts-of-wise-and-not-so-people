using DsrProject.Services.EmailSender;
using System.Threading.Tasks;

namespace DsrProject.Services.Actions
{
    public interface IAction
    {
        Task SendEmail(EmailModel email);
    }
}