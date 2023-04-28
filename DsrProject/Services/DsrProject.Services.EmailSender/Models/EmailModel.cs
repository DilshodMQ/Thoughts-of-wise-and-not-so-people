
namespace DsrProject.Services.EmailSender
{

    public class EmailModel
    {
        public string RespondentEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public int ThoughtId { get; set; }
    }
}